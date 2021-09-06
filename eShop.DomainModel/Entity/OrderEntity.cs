using eShop.DomainModel.ValueObjects;
using System;

namespace eShop.DomainModel.Entity
{
    public class OrderEntity : Base
    {
        public Guid Id { get; set; }
        public Guid OrderStatusId { get; set; }
        public string OrderStatus { get; set; }
        public Guid UserId { get; set; }
        public string UserName { get; set; }      
        public decimal TotalPrice { get; set; }
        public string UserAddress { get; set; }
    }

    public class OrdeDetailsEntity : Base
    {
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        public string ProductImage { get; set; }
        public string ProductName { get; set; }
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }
    }

    public class OrderStatusEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

    }
}
