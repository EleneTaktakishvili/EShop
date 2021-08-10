using System;

namespace eShop.DataTransferObject.DTOModels
{
    public class ProductDTO : BaseDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal Quantity { get; set; }
        public string ImagePath { get; set; }
        public Guid CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
