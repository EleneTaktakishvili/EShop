﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

#nullable disable

namespace eShop.DataBaseRepository.Db.Models
{
    public partial class OrderStatus
    {
        public OrderStatus()
        {
            Orders = new HashSet<Orders>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Orders> Orders { get; set; }
    }
}