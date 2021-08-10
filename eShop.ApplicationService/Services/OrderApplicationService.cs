using eShop.ApplicationService.ServiceInterfaces;
using eShop.DataTransferObject.DTOModels;
using eShop.DomainService.ServiceInterfaces;
using System.Collections.Generic;


namespace eShop.ApplicationService.Services
{
    public class OrderApplicationService : IOrderApplicationService
    {
        private IOrderDomainService _OrderDomainService;

        public OrderApplicationService(IOrderDomainService OrderDomainService)
        {
            _OrderDomainService = OrderDomainService;
        }

        public ICollection<OrderDTO> GetAll()
        {
            ICollection<OrderDTO> orderDTO = new List<OrderDTO>();
            var list = _OrderDomainService.GetAll();

            foreach (var item in list)
            {
                orderDTO.Add(new OrderDTO
                {
                    Id = item.Id,
                    OrderStatusId = item.OrderStatusId,
                    OrderStatus = item.OrderStatus,
                    UserId = item.Id,
                    UserName = item.UserName,
                    UserAddress = item.UserAddress,
                    TotalPrice = item.TotalPrice,
                    DateCreated = item.DateCreated,
                    DateChanged = item.DateChanged,
                    DateDeleted = item.DateDeleted

                });
            }
            return orderDTO;
        }
    }
}
