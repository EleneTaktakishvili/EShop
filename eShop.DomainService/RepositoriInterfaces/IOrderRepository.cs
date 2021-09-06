using eShop.DomainModel.Entity;
using System;
using System.Collections.Generic;

namespace eShop.DomainService.RepositoriInterfaces
{
    public interface IOrderRepository
    {
        ICollection<OrderEntity> GetAll();
        ICollection<OrdeDetailsEntity> GetDetails(Guid Id);
        ICollection<OrderStatusEntity> GetOrderStatus();
        string AddOrder(Guid UserId, Guid ProductId, int Quantity);
        int GetCartCount(Guid UserId);
        void ApplyOrder(Guid OrderId, Guid AddressId);
        ICollection<OrderEntity> GetOrdersHistory(Guid UserId);
        ICollection<OrdeDetailsEntity> GetOrderDetails(Guid OrderId);
        void AddAddress(UserAddressEntity userAddressEntity);
    }
}
