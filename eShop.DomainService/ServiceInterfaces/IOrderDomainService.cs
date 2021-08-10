using eShop.DomainModel.Entity;
using System.Collections.Generic;


namespace eShop.DomainService.ServiceInterfaces
{
    public interface IOrderDomainService
    {
        ICollection<OrderEntity> GetAll();
    }
}
