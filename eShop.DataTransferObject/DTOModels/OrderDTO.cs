using System;

namespace eShop.DataTransferObject.DTOModels
{
    public class OrderDTO : BaseDTO
    {
        public Guid Id { get; set; }
        public Guid OrderStatusId { get; set; }
        public string OrderStatus { get; set; }
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public decimal TotalPrice { get; set; }
        public string UserAddress { get; set; }
    }

    public class OrdeDetailsDTO : BaseDTO
    {
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductImage { get; set; }
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }
    }

    public class OrderStatusDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
