﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

#nullable disable

namespace eShop.DataBaseRepository.Db.Models
{
    public partial class ProductImages
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public string ImagePath { get; set; }
        public bool IsMain { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateChanged { get; set; }
        public DateTime? DateDeleted { get; set; }

        public virtual Products Product { get; set; }
    }
}