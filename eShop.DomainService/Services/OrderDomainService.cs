using eShop.DomainModel.Entity;
using eShop.DomainService.RepositoriInterfaces;
using eShop.DomainService.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.DomainService.Services
{
    public class OrderDomainService : IOrderDomainService
    {
        private IOrderRepository _OrderRepository;

        public OrderDomainService(IOrderRepository OrderRepository)
        {
            _OrderRepository = OrderRepository;
        }
       
        public ICollection<OrderEntity> GetAll()
        {
            return _OrderRepository.GetAll();
        }

        public ICollection<OrdeDetailsEntity> GetDetails(Guid Id)
        {
            return _OrderRepository.GetDetails(Id);
        }

        public ICollection<OrderStatusEntity> GetOrderStatus()
        {
            return _OrderRepository.GetOrderStatus();
        }
        public string AddOrder(Guid UserId, Guid ProductId, int Quantity)
        {
            return _OrderRepository.AddOrder(UserId, ProductId, Quantity);
        }
        public int GetCartCount(Guid UserId)
        {
            return _OrderRepository.GetCartCount(UserId);
        }

        public void ApplyOrder(Guid OrderId, Guid AddressId)
        {
            _OrderRepository.ApplyOrder(OrderId, AddressId);
        }

        public ICollection<OrderEntity> GetOrdersHistory(Guid UserId)
        {
            return _OrderRepository.GetOrdersHistory(UserId);
        }

        public ICollection<OrdeDetailsEntity> GetOrderDetails(Guid OrderId)
        {
            return _OrderRepository.GetOrderDetails(OrderId);
        }

        public void AddAddress(UserAddressEntity userAddressEntity)
        {
            _OrderRepository.AddAddress(userAddressEntity);
        }
    }
}
