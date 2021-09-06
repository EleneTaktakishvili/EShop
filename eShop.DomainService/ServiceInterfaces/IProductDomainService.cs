using eShop.DomainModel.Entity;
using eShop.Utility;
using System;
using System.Collections.Generic;

namespace eShop.DomainService.ServiceInterfaces
{
    public interface IProductDomainService
    {
        PagedResults<ProductEntity> GetAll(int PageNo, int PageSize);
        ProductDetailsEntity GetDetails(Guid ProductId);
        ICollection<ProductEntity> GetRelatedProducts(List<Guid> CategoryIds);      
        ProductsInCartWithTotalEntity GetCartDetails(Guid UserId);
    }
}
