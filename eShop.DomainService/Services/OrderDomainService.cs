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
        
    }
}
