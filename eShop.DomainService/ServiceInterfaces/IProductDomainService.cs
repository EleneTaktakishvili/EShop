using eShop.DomainModel.Entity;
using System.Collections.Generic;

namespace eShop.DomainService.ServiceInterfaces
{
    public interface IProductDomainService
    {
        ICollection<ProductEntity> GetAll();
    }
}
