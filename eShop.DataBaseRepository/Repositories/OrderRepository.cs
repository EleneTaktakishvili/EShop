using Dapper;
using eShop.DataBaseRepository.Dapper;
using eShop.DataBaseRepository.Db;
using eShop.DomainModel.Entity;
using eShop.DomainService.RepositoriInterfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace eShop.DataBaseRepository.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DapperContext _context;
        public OrderRepository(DapperContext context)
        {
            _context = context;
        }
        public string AddOrder(Guid UserId, Guid ProductId, int Quantity)
        {
            using (var connection = _context.CreateConnection())
            {                
                string procName = "AddNewOrder";
                var _params = new DynamicParameters();
                _params.Add("@UserId", UserId);
                _params.Add("@ProductId", ProductId);
                _params.Add("@Quantity", Quantity);
                _params.Add("@Result", dbType: DbType.String, direction: ParameterDirection.Output, size:100);

                connection.Query(procName, _params, commandType: CommandType.StoredProcedure);

                return  _params.Get<string>("Result");
            }
        }

        public int GetCartCount(Guid UserId)
        {
            using (var connection = _context.CreateConnection())
            {
                string procName = "GetCartCount";
                var _params = new DynamicParameters();
                _params.Add("@UserId", UserId);
                _params.Add("@Result", dbType: DbType.Int32, direction: ParameterDirection.Output);

                connection.Query(procName, _params, commandType: CommandType.StoredProcedure);

                return _params.Get<int>("Result");
            }
        }

        public ICollection<OrderEntity> GetAll()
        {
            ICollection<OrderEntity> orderEntity = new List<OrderEntity>();

            //using (eShopDbContext context = new eShopDbContext())
            //{
            //    orderEntity = (from order in context.Orders
            //                   join status in context.OrderStatus on order.OrderStatusId equals status.Id
            //                   join address in context.UserAddress on order.AddressId equals address.Id
            //                   join user in context.Users on order.UserId equals user.Id
            //                   select new OrderEntity
            //                   {
            //                       Id = order.Id,
            //                       OrderStatusId = order.OrderStatusId,
            //                       OrderStatus = status.Name,
            //                       UserId = user.Id,
            //                       UserName = $"{user.FirtsName} {user.LastName}",
            //                       UserAddress = $"{address.City} , {address.Address}",
            //                       TotalPrice = order.TotalPrice,
            //                       DateCreated = order.DateCreated,
            //                       DateChanged = order.DateChanged,
            //                       DateDeleted = order.DateDeleted

            //                   }).ToList();

            //}
            return orderEntity;
        }

        public ICollection<OrdeDetailsEntity> GetDetails(Guid Id)
        {
            ICollection<OrdeDetailsEntity> orderDetailsEntity = new List<OrdeDetailsEntity>();
            //using (eShopDbContext context = new eShopDbContext())
            //{
            //    orderDetailsEntity = (from orderDetails in context.OrderDetails
            //                          where orderDetails.OrderId == Id
            //                          select new OrdeDetailsEntity
            //                          {
            //                              Id = orderDetails.Id,
            //                              OrderId = orderDetails.OrderId,
            //                              ProductId = orderDetails.ProductId,
            //                              ProductName = orderDetails.Product.Name,
            //                              ProductImage = orderDetails.Product.ProductImages.Where(i => i.IsMain).Select(i => i.ImagePath).SingleOrDefault(),
            //                              Price = orderDetails.Price,
            //                              Quantity = orderDetails.Quantity,
            //                              DateCreated = orderDetails.DateCreated,
            //                              DateChanged = orderDetails.DateChanged,
            //                              DateDeleted = orderDetails.DateDeleted
            //                          }).ToList();
            //}
            return orderDetailsEntity;
        }

        public ICollection<OrderStatusEntity> GetOrderStatus()
        {
            ICollection<OrderStatusEntity> orderStatusEntity = new List<OrderStatusEntity>();

            //using (eShopDbContext context = new eShopDbContext())
            //{
            //    orderStatusEntity = (from orderstatus in context.OrderStatus
            //                         select new OrderStatusEntity
            //                         {
            //                             Id = orderstatus.Id,
            //                             Name = orderstatus.Name
            //                         }).ToList();
            //}
            return orderStatusEntity;
        }

        public void ApplyOrder(Guid OrderId, Guid AddressId)
        {
            using (var connection = _context.CreateConnection())
            {
                string procName = "ApplyOrder";
                var _params = new DynamicParameters();
                _params.Add("@OrderId", OrderId);
                _params.Add("@AddressId", AddressId);
                
                connection.Query(procName, _params, commandType: CommandType.StoredProcedure);
              
            }
        }

        public ICollection<OrderEntity> GetOrdersHistory(Guid UserId)
        {
            using (var connection = _context.CreateConnection())
            {
                ICollection<OrderEntity> orderEntity = new List<OrderEntity>();
                string procName = "OrderHistory";
                var _params = new DynamicParameters();
                _params.Add("@UserId", UserId);

                orderEntity = connection.Query<OrderEntity>(procName, _params, commandType: CommandType.StoredProcedure).ToList();

                return orderEntity;
            }
        }

        public ICollection<OrdeDetailsEntity> GetOrderDetails(Guid OrderId)
        {
            using (var connection = _context.CreateConnection())
            {
                ICollection<OrdeDetailsEntity> ordeDetailsEntity = new List<OrdeDetailsEntity>();
                string procName = "OrderDetailsHistory";
                var _params = new DynamicParameters();
                _params.Add("@OrderId", OrderId);

                ordeDetailsEntity = connection.Query<OrdeDetailsEntity>(procName, _params, commandType: CommandType.StoredProcedure).ToList();

                return ordeDetailsEntity;
            }
        }

        public void AddAddress(UserAddressEntity userAddressEntity)
        {

            using (var connection = _context.CreateConnection())
            {
                string procName = "AddAddress";
                var _params = new DynamicParameters();
                _params.Add("@UserId", userAddressEntity.UserId);
                _params.Add("@City", userAddressEntity.City);
                _params.Add("@Address", userAddressEntity.Address);

                connection.Query(procName, _params, commandType: CommandType.StoredProcedure);

            }
        }
    }
}
