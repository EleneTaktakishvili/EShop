using eShop.DomainModel.Entity;
using System.Collections.Generic;

namespace eShop.DomainService.RepositoriInterfaces
{
    public interface IOrderRepository
    {
        ICollection<OrderEntity> GetAll();
    }
}
