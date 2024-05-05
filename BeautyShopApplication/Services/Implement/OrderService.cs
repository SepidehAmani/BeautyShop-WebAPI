using BeautyShopApplication.Services.Interface;
using BeautyShopDomain.DTOs;
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

    public OrderService(IOrderRepository orderRepository, IOrderItemRepository orderItemRepository,
        IProductItemRepository productItemRepository)
    {
        _orderRepository = orderRepository;
        _orderItemRepository = orderItemRepository;
        _productItemRepository = productItemRepository;
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


    public async Task<bool> PayShopCard(int userId,CancellationToken cancellation)
    {
        var openOrder = await _orderRepository.GetOpenOrderByUserId(userId, cancellation);
        if (openOrder == null) return false;

        var itemsCount = await _orderItemRepository.GetCountOfCurrentShopItems(openOrder.Id, cancellation);
        if (itemsCount == 0) return false;

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
}
