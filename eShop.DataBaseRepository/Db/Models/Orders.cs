﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

#nullable disable

namespace eShop.DataBaseRepository.Db.Models
{
    public partial class Orders
    {
        public Orders()
        {
            OrderDetails = new HashSet<OrderDetails>();
        }

        public Guid Id { get; set; }
        public Guid OrderStatusId { get; set; }
        public Guid UserId { get; set; }
        public decimal TotalPrice { get; set; }
        public string UserAddress { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateChanged { get; set; }
        public DateTime? DateDeleted { get; set; }

        public virtual OrderStatus OrderStatus { get; set; }
        public virtual Users User { get; set; }
        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
    }
}