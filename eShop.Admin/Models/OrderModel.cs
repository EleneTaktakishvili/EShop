using System;
using System.ComponentModel;

namespace eShop.Admin.Models
{
    public class OrderModel : BaseModel
    {
        public Guid Id { get; set; }
        public Guid OrderStatusId { get; set; }

        [DisplayName("შეკვეთის სტატუსი")]
        public string OrderStatus { get; set; }
        public Guid UserId { get; set; }

        [DisplayName("მომხმარებელი")]
        public string UserName { get; set; }

        [DisplayName("ჯამი")]
        public decimal TotalPrice { get; set; }

        [DisplayName("მისამართი")]
        public string UserAddress { get; set; }
    }
}
