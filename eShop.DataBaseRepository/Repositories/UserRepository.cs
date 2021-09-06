using Dapper;
using eShop.DataBaseRepository.Dapper;
using eShop.DomainModel.Entity;
using eShop.DomainService.RepositoriInterfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace eShop.DataBaseRepository.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DapperContext _context;
        public UserRepository(DapperContext context)
        {
            _context = context;
        }
        public ICollection<UserEntity> GetAll()
        {
            ICollection<UserEntity> userEntity = new List<UserEntity>();

            //using (eShopDbContext context = new eShopDbContext())
            //{
            //    userEntity = (from u in context.UsersInRoles
            //                  select new UserEntity
            //                  {
            //                      Id = u.User.Id,
            //                      FirtsName = u.User.FirtsName,
            //                      LastName = u.User.LastName,
            //                      Email = u.User.Email,
            //                      IsActive = u.User.IsActive,
            //                      RoleId = u.RoleId,
            //                      RoleName = u.Role.Name
            //                  }).ToList();

            //}
            return userEntity;
        }

        public bool Login(UserEntity UserEntity)
        {
            using (var connection = _context.CreateConnection())
            {
                string procName = "UserLogin";
                var _params = new DynamicParameters();
                _params.Add("@Email", UserEntity.Email);
                _params.Add("@Password", UserEntity.PasswordHash);
                _params.Add("@SessionId", UserEntity.SessionId);
                _params.Add("@Result", dbType: DbType.Int16, direction: ParameterDirection.Output);

                connection.Query(procName, _params, commandType: CommandType.StoredProcedure);

                var result = _params.Get<Int16>("Result");

                return result == 0 ? true : false;
            }         
        }

        public bool CheckSessionIsValid(Guid SessionID)
        {
            using (var connection = _context.CreateConnection())
            {
                
                string procName = "CheckSessionIsValid";
                var _params = new DynamicParameters();
                _params.Add("@SessionId", SessionID);
                _params.Add("@Result", dbType: DbType.Int16, direction: ParameterDirection.Output);

                connection.Query(procName, _params, commandType: CommandType.StoredProcedure);

                var result = _params.Get<Int16>("Result");

                return result == 0 ? true : false;              
            }          
        }

        public List<string> Registration(UserEntity User)
        {
            using (var connection = _context.CreateConnection())
            {
                List<string> registrationResponse = new List<string>();
              
                string procName = "UserRegistration";
                var _params = new DynamicParameters();
                _params.Add("@Email", User.Email);
                _params.Add("@FirstName", User.FirtsName);
                _params.Add("@LastName", User.LastName);
                _params.Add("@Password", User.PasswordHash);
                _params.Add("@Code", dbType: DbType.String, direction: ParameterDirection.Output, size: 500);
                _params.Add("@Result", dbType: DbType.String, direction: ParameterDirection.Output, size:500);

                connection.Query(procName, _params, commandType: CommandType.StoredProcedure).ToList();

                var code = _params.Get<string>("Code"); 

                string link =$"აქტივაციისთვის გადადით შემდეგ ლინკზე: https://localhost:44320/Auth/Activation?code={code}";


                registrationResponse.Add( _params.Get<string>("Result"));
                registrationResponse.Add(link);

                return registrationResponse;
            }
        }
        public ICollection<UserAddressEntity> GetUserAddress(Guid UserId)
        {
            using (var connection = _context.CreateConnection())
            {
                List<UserAddressEntity> userAddressEntity = new List<UserAddressEntity>();
                string procName = "GetUserAddress";
                var _params = new DynamicParameters();
                _params.Add("@UserId", UserId);

                userAddressEntity = connection.Query<UserAddressEntity>(procName, _params, commandType: CommandType.StoredProcedure).ToList();

                return userAddressEntity;
            }
        }
    }

}
