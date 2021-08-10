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
}
