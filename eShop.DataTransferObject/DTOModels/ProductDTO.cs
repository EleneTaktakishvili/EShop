using System;
using System.Collections.Generic;

namespace eShop.DataTransferObject.DTOModels
{
    public class ProductDTO : BaseDTO
    {
        public Guid ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string ImagePath { get; set; }
    }

    public class ProductDetailsDTO 
    {
        public Guid ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public ICollection<CategoryDTO> Categories { get; set; }
        public ICollection<ImageDTO> Images { get; set; }
    }


    public class ProductsInCartDTO
    {
        public Guid OrdertId { get; set; }
        public Guid ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal Quantity { get; set; }
        public decimal TotalPrice { get; set; }
    }

    public class ProductsInCarWithTotalDTO
    {
        public List<ProductsInCartDTO> productsInCart { get; set; }
        public List<UserAddressDTO> userAddress { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
