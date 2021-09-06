using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eShop.Admin.Models
{
    public class ProductModel : BaseModel
    {
        public Guid Id { get; set; }

        [DisplayName("დასახელება")]
        public string Name { get; set; }

        [DisplayName("აღწერა")]
        public string Description { get; set; }

        [Range(1, 1000)]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        [DisplayName("ფასი")]
        public decimal Price { get; set; }

        [DisplayName("რაოდენობა")]
        public decimal Quantity { get; set; }

        [DisplayName("სურათი")]
        public string ImagePath { get; set; }
        public Guid CategoryId { get; set; }

        [DisplayName("კატეგორია")]
        public string CategoryName { get; set; }

        public List<IFormFile> Photos { get; set; }

        public List<Guid> CategoryIds { get; set; }
    }
}
