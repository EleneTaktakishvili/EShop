using System;
using System.ComponentModel;

namespace eShop.Admin.Models
{
    public class ProductModel : BaseModel
    {
        public Guid Id { get; set; }

        [DisplayName("დასახელება")]
        public string Name { get; set; }

        [DisplayName("აღწერა")]
        public string Description { get; set; }

        [DisplayName("ფასი")]
        public decimal Price { get; set; }

        [DisplayName("რაოდენობა")]
        public decimal Quantity { get; set; }

        [DisplayName("სურათი")]
        public string ImagePath { get; set; }
        public Guid CategoryId { get; set; }

        [DisplayName("კატეგორია")]
        public string CategoryName { get; set; }
    }
}
