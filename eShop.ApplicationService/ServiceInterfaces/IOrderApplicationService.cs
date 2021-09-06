using eShop.DataTransferObject.DTOModels;
using System;
using System.Collections.Generic;

namespace eShop.ApplicationService.ServiceInterfaces
{
    public interface IOrderApplicationService
    {
        ICollection<OrderDTO> GetAll();
        ICollection<OrdeDetailsDTO> GetDetails(Guid Id);
        ICollection<OrderStatusDTO> GetOrderStatus();
        string AddOrder(Guid UserId, Guid ProductId, int Quantity);
        int GetCartCount(Guid UserId);
        void ApplyOrder(Guid OrderId, Guid AddressId);
        ICollection<OrderDTO> GetOrdersHistory(Guid UserId);
        ICollection<OrdeDetailsDTO> GetOrderDetails(Guid OrderId);
        void AddAddress(UserAddressDTO userAddressDTO);
    }
}
