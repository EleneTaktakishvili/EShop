using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        [DisplayName("ჯამი")]
        public decimal TotalPrice { get; set; }

        [DisplayName("მისამართი")]
        public string UserAddress { get; set; }
    }

    public class OrdeDetailsModel : BaseModel
    {
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        public string ProductImage { get; set; }
        public string ProductName { get; set; }
        public decimal Quantity { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }
    }
}
