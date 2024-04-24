﻿using BeautyShopDomain.Entities.Base;
using BeautyShopDomain.Entities.Order;

namespace BeautyShopDomain.Entities.Product;

public class ProductItem : BaseEntity
{
    public int ProductId { get; set; }
    public string? Image { get; set; }
    public string Color { get; set; }
    public int Quantity { get; set; }
    public bool IsDelete { get; set; }
    

    public ICollection<OrderItem>? OrderItems { get; set; }
    public Product? Product { get; set; }
}
