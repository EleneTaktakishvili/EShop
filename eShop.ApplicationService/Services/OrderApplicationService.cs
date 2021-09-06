using eShop.ApplicationService.ServiceInterfaces;
using eShop.DataTransferObject.DTOModels;
using eShop.DomainModel.Entity;
using eShop.DomainService.ServiceInterfaces;
using System;
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

        public ICollection<OrdeDetailsDTO> GetDetails(Guid Id)
        {
            ICollection<OrdeDetailsDTO> ordeDetailsDTO = new List<OrdeDetailsDTO>();
            var list = _OrderDomainService.GetDetails(Id);

            foreach (var item in list)
            {
                ordeDetailsDTO.Add(new OrdeDetailsDTO
                {
                    Id = item.Id,
                    OrderId = item.OrderId,
                    ProductId = item.ProductId,
                    ProductName = item.ProductName,
                    ProductImage = item.ProductImage,
                    Price = item.Price,
                    Quantity = item.Quantity,
                    DateCreated = item.DateCreated,
                    DateChanged = item.DateChanged,
                    DateDeleted = item.DateDeleted
                });
            }
            return ordeDetailsDTO;
        }

        public ICollection<OrderStatusDTO> GetOrderStatus()
        {
            ICollection<OrderStatusDTO> orderstatusDTO = new List<OrderStatusDTO>();
            var list = _OrderDomainService.GetOrderStatus();
            foreach (var item in list)
            {
                orderstatusDTO.Add(new OrderStatusDTO
                {
                    Id = item.Id,
                    Name = item.Name
                });
            }
            return orderstatusDTO;
        }

        public string AddOrder(Guid UserId, Guid ProductId, int Quantity)
        {
            return _OrderDomainService.AddOrder(UserId, ProductId, Quantity);
        }

        public int GetCartCount(Guid UserId)
        {
            return _OrderDomainService.GetCartCount(UserId);
        }

        public void ApplyOrder(Guid OrderId, Guid AddressId)
        {
            _OrderDomainService.ApplyOrder(OrderId, AddressId);
        }

        public ICollection<OrderDTO> GetOrdersHistory(Guid UserId)
        {
            ICollection<OrderDTO> orderDTO = new List<OrderDTO>();

            var list = _OrderDomainService.GetOrdersHistory(UserId);

            foreach (var item in list)
            {
                orderDTO.Add(new OrderDTO
                {
                    Id = item.Id,
                    OrderStatus = item.OrderStatus,
                    TotalPrice = item.TotalPrice,
                    DateCreated = item.DateCreated
                });
            }
            return orderDTO;
        }

        public ICollection<OrdeDetailsDTO> GetOrderDetails(Guid OrderId)
        {
            ICollection<OrdeDetailsDTO> ordeDetailsDTO = new List<OrdeDetailsDTO>();

            var list = _OrderDomainService.GetOrderDetails(OrderId);

            foreach (var item in list)
            {
                ordeDetailsDTO.Add(new OrdeDetailsDTO
                {
                    Id = item.Id,
                    ProductName = item.ProductName,
                    Quantity = item.Quantity,
                    Price = item.Price
                });
            }
            return ordeDetailsDTO;
        }

        public void AddAddress(UserAddressDTO userAddressDTO)
        {
            UserAddressEntity userAddressEntity = new UserAddressEntity();
            userAddressEntity.ID = userAddressDTO.ID;
            userAddressEntity.UserId = userAddressDTO.UserId;
            userAddressEntity.City = userAddressDTO.City;
            userAddressEntity.Address = userAddressDTO.Address;

            _OrderDomainService.AddAddress(userAddressEntity);
        }
    }
}
