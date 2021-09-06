using eShop.DataTransferObject.DTOModels;
using eShop.Utility;
using System;
using System.Collections.Generic;

namespace eShop.ApplicationService.ServiceInterfaces
{
    public interface IProductApplicationService
    {
        PagedResults<ProductDTO> GetAll(int PageNo, int PageSize);
        ProductDetailsDTO GetDetails(Guid ProductId);
        ICollection<ProductDTO> GetRelatedProducts(List<Guid> CategoryIds);     
        ProductsInCarWithTotalDTO GetCartDetails(Guid UserId);
    }
}
