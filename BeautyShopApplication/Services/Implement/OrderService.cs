using BeautyShopApplication.Services.Interface;
using BeautyShopDomain.DTOs;
using BeautyShopDomain.DTOs.AdminSide;
using BeautyShopDomain.Entities.Order;
using BeautyShopDomain.Enums;
using BeautyShopDomain.RepositoryInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace BeautyShopApplication.Services.Implement;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;
    private readonly IOrderItemRepository _orderItemRepository;
    private readonly IProductItemRepository _productItemRepository;
    private readonly IUserRepository _userRepository;

    public OrderService(IOrderRepository orderRepository, IOrderItemRepository orderItemRepository,
        IProductItemRepository productItemRepository,IUserRepository userRepository)
    {
        _orderRepository = orderRepository;
        _orderItemRepository = orderItemRepository;
        _productItemRepository = productItemRepository;
        _userRepository = userRepository;
    }


    public async Task<bool> AddItemToShopCard(AddToShopCardDTO addToShopCardDTO, int userId, CancellationToken cancellation)
    {
        var productItem = await _productItemRepository.GetProductItemById(addToShopCardDTO.ProductItemId, cancellation);
        if (productItem == null) return false;
        if(productItem.Quantity < addToShopCardDTO.Quantity) return false;

        var openOrder = await _orderRepository.GetOpenOrderByUserId(userId, cancellation);
        if (openOrder == null)
        {
            var orderEntity = new Order()
            {
                UserId = userId,
                Status = OrderStatus.Open
            };

            _orderRepository.AddOrder(orderEntity);
            await _orderRepository.SaveChangesAsync(cancellation);
            openOrder = orderEntity;
        }

        var orderItemEntity = new OrderItem()
        {
            ProductItemId = addToShopCardDTO.ProductItemId,
            OrderId = openOrder.Id,
            OrderCount = addToShopCardDTO.Quantity
        };
        _orderItemRepository.AddOrderItem(orderItemEntity);
        await _orderItemRepository.SaveChangesAsync(cancellation);

        return true;
    }

    public async Task<ShowShopCardDTO?> GetShopCard(int userId, CancellationToken cancellation)
    {
        var openOrder = await _orderRepository.GetOpenOrderByUserId(userId, cancellation);
        if (openOrder == null) return null;

        return new ShowShopCardDTO()
        {
            CreateDate = openOrder.CreateDate,
            OrderId = openOrder.Id,
            orderItems = await _orderItemRepository.GetOrderItemDTOsByOrderId(openOrder.Id, cancellation)
        };
    }


    public async Task<bool> RemoveItemFromShopCard(int orderItemId,int userId, CancellationToken cancellation)
    {
        var openOrder = await _orderRepository.GetOpenOrderByUserId(userId, cancellation);
        if (openOrder == null) return false;

        var orderItem = await _orderItemRepository.GetOrderItemById(orderItemId, cancellation);
        if(orderItem == null) return false;

        orderItem.IsDelete = true;
        _orderItemRepository.UpdateOrderItem(orderItem);
        await _orderItemRepository.SaveChangesAsync(cancellation);

        var remainingItemsCount = await _orderItemRepository.GetCountOfCurrentShopItems(openOrder.Id, cancellation);
        if(remainingItemsCount == 0)
        {
            openOrder.IsDelete = true;
            _orderRepository.UpdateOrder(openOrder);
            await _orderRepository.SaveChangesAsync(cancellation);
        }

        return true;
    }


    public async Task<bool> RemoveShopCard(int userId,CancellationToken cancellation)
    {
        var openOrder = await _orderRepository.GetOpenOrderByUserId(userId, cancellation);
        if (openOrder == null) return false;

        openOrder.IsDelete = true;
        _orderRepository.UpdateOrder(openOrder);
        
        var orderItems = await _orderItemRepository.GetOrderItemsByOrderId(openOrder.Id, cancellation);
        if( orderItems != null)
        {
            foreach (var item in orderItems)
            {
                item.IsDelete = true;
                _orderItemRepository.UpdateOrderItem(item);
            }
        }

        await _orderRepository.SaveChangesAsync(cancellation);
        return true;
    }


    public async Task<bool> PayShopCard(int userId,AddressDTO addressDTO,CancellationToken cancellation)
    {
        var openOrder = await _orderRepository.GetOpenOrderByUserId(userId, cancellation);
        if (openOrder == null) return false;

        var OrderItems = await _orderItemRepository.GetOrderItemsByOrderId(openOrder.Id, cancellation);
        if (OrderItems == null) return false;

        foreach (var item in OrderItems)
        {
            var productItem = await _productItemRepository.GetProductItemById(item.ProductItemId, cancellation);
            if (productItem == null) return false;
            productItem.Quantity -= item.OrderCount;
            if (productItem.Quantity < 0) return false;
            _productItemRepository.UpdateProductItem(productItem);
        }

        openOrder.Address = addressDTO.Address;
        openOrder.PostalCode = addressDTO.PostalCode;
        openOrder.Status = OrderStatus.Closed;
        _orderRepository.UpdateOrder(openOrder);
        await _orderRepository.SaveChangesAsync(cancellation);

        return true;
    }


    public async Task<bool> OrderPayed(int orderId,int userId,CancellationToken cancellation)
    {
        var order = await _orderRepository.GetClosedOrderById(orderId, cancellation);
        if(order == null) return false;
        if(order.UserId != userId) return false;

        order.Status = OrderStatus.Payed;
        _orderRepository.UpdateOrder(order);
        await _orderRepository.SaveChangesAsync(cancellation);
        return true;
    }


    public async Task<ICollection<ListOfOrdersDTO>?> GetListOfPayedOrders(CancellationToken cancellation)
    {
        var Orders = await _orderRepository.GetListOfPayedOrders(cancellation);
        if(Orders == null) return null;

        var OrderDTOs = new List<ListOfOrdersDTO>();
        foreach(var order in Orders)
        {
            OrderDTOs.Add(new ListOfOrdersDTO()
            {
                OrderId = order.Id,
                UserName = (await _userRepository.GetUserById(order.UserId,cancellation)).Username,
                IsSeen = order.IsSeen,
                Status = order.Status
            });
        }

        return OrderDTOs;

    }

    public async Task<OrderDetailDTO?> GetPayedOrderInDetail(int OrderId, CancellationToken cancellation)
    {
        var order = await _orderRepository.GetOrderWithItemsById(OrderId,cancellation);
        if(order == null) return null;
        if(order.Status == OrderStatus.Open || order.Status == OrderStatus.Open) return null;

        var items = new List<OrderItemDetailDTO>();
        foreach(var item in order.OrderItems)
        {
            var productItemWithProduct = await _productItemRepository.GetProductItemWithProductById(item.ProductItemId, cancellation);
            items.Add(new OrderItemDetailDTO()
            {
                Color = productItemWithProduct.Color,
                Count = item.OrderCount,
                OrderItemId = item.Id,
                ProductName = productItemWithProduct.Product.Name
            });
        }

        var model = new OrderDetailDTO()
        {
            OrderId = order.Id,
            Status = order.Status,
            UserName = (await _userRepository.GetUserById(order.UserId, cancellation)).Username,
            Items = items
        };

        if(order.IsSeen == false)
        {
            order.IsSeen = true;
            _orderRepository.UpdateOrder(order);
            await _orderRepository.SaveChangesAsync(cancellation);
        }

        return model;
    }

    public async Task<bool> ShippOrder(int orderId, CancellationToken cancellation)
    {
        var order = await _orderRepository.GetOrderById(orderId, cancellation);
        if(order == null || order.Status != OrderStatus.Payed) return false;

        order.Status = OrderStatus.Shipped;
        _orderRepository.UpdateOrder(order);
        await _orderRepository.SaveChangesAsync(cancellation);

        return true;
    }
}
