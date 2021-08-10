using eShop.DataBaseRepository.Db;
using eShop.DomainModel.Entity;
using eShop.DomainService.RepositoriInterfaces;
using System.Collections.Generic;
using System.Linq;

namespace eShop.DataBaseRepository.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        public ICollection<OrderEntity> GetAll()
        {
            var orderEntity = new List<OrderEntity>();

            using (eShopDbContext context = new eShopDbContext())
            {
                orderEntity = (from order in context.Orders
                               join status in context.OrderStatus on order.OrderStatusId equals status.Id
                               join user in context.Users on order.UserId equals user.Id
                               select new OrderEntity
                               {
                                   Id = order.Id,
                                   OrderStatusId = order.OrderStatusId,
                                   OrderStatus = status.Name,
                                   UserId = user.Id,
                                   UserName = user.FirtsName + user.LastName,
                                   UserAddress = order.UserAddress,
                                   TotalPrice = order.TotalPrice,
                                   DateCreated = order.DateCreated,
                                   DateChanged = order.DateChanged,
                                   DateDeleted = order.DateDeleted

                               }).ToList();

            }
            return orderEntity;
        }
    }
}
