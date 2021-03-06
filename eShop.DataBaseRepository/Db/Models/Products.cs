// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

#nullable disable

namespace eShop.DataBaseRepository.Db.Models
{
    /// <summary>
    /// /category
    /// </summary>
    public partial class Products
    {
        public Products()
        {
            OrderDetails = new HashSet<OrderDetails>();
            ProductImages = new HashSet<ProductImages>();
            ProductsInCategory = new HashSet<ProductsInCategory>();
        }

        public Guid ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal Quantity { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateChanged { get; set; }
        public DateTime? DateDeleted { get; set; }

        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
        public virtual ICollection<ProductImages> ProductImages { get; set; }
        public virtual ICollection<ProductsInCategory> ProductsInCategory { get; set; }
    }
}