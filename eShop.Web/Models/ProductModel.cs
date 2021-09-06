using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eShop.Web.Models
{
    public class ProductModel
    {
        public Guid ProductId { get; set; }     
        public string Name { get; set; } 
        public decimal Price { get; set; }       
        public string ImagePath { get; set; }       
    }

    public class ProductDetailsModel 
    {
        public Guid ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public ICollection<CategoryModel> Categories { get; set; }
        public ICollection<ImageModel> Images { get; set; }
    }

    public class ProductDetailsWithRelatedProducts
    {
        public ProductDetailsModel ProductDetails { get; set; }
        public ICollection<ProductModel> RelatedProducts { get; set; }
    }

    public class ProductsInCartModel
    {
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal Quantity { get; set; }
       
    }

    public class CartWithAddresstModel
    {
        public  List<ProductsInCartModel> productsInCart { get; set; }
        public List<UserAddressModel> userAddresses { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
