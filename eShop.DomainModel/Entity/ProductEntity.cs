using eShop.DomainModel.ValueObjects;
using System;
using System.Collections.Generic;

namespace eShop.DomainModel.Entity
{
    public class ProductEntity : Base
    {
        public Guid ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string ImagePath { get; set; }
    }

    public class ProductDetailsEntity
    {
        public Guid ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public ICollection<CategoryEntity> Categories { get; set; }
        public ICollection<ImageEntity> Images { get; set; }
    }

    public class ProductsInCartEntity
    {
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal Quantity { get; set; }
    }

    public class ProductsInCartWithTotalEntity
    {
        public List<ProductsInCartEntity> productsInCart { get; set; }

        public List<UserAddressEntity> userAddress { get; set; }
        public decimal TotalPrice { get; set; }
    }

}
