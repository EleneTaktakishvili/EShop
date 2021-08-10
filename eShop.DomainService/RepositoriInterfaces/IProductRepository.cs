using eShop.DomainModel.Entity;
using System.Collections.Generic;

namespace eShop.DomainService.RepositoriInterfaces
{
    public interface IProductRepository
    {
        ICollection<ProductEntity> GetAll();
    }
}
