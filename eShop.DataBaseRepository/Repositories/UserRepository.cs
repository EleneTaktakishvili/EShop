using eShop.DataBaseRepository.Db;
using eShop.DataBaseRepository.Db.Models;
using eShop.DomainModel.Entity;
using eShop.DomainService.RepositoriInterfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace eShop.DataBaseRepository.Repositories
{
    public class UserRepository : IUserRepository
    {
        public ICollection<UserEntity> GetAll()
        {
            ICollection<UserEntity> userEntity = new List<UserEntity>();

            using (eShopDbContext context = new eShopDbContext())
            {
                userEntity = (from u in context.UsersInRoles
                              select new UserEntity
                              {
                                  Id = u.User.Id,
                                  FirtsName = u.User.FirtsName,
                                  LastName = u.User.LastName,
                                  Email = u.User.Email,
                                  IsActive = u.User.IsActive,
                                  RoleId = u.RoleId,
                                  RoleName = u.Role.Name
                              }).ToList();

            }
            return userEntity;
        }

        public bool Login(UserEntity UserEntity)
        {
            using (eShopDbContext context = new eShopDbContext())
            {
                var query = (from user in context.Users
                             where user.Email == UserEntity.Email &&
                             user.PasswordHash == UserEntity.PasswordHash &&
                             user.IsActive == true &&
                             user.DateDeleted == null
                             select user).FirstOrDefault();

                if (query != null)
                {
                    query.SessionId = UserEntity.SessionId;
                    context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }

            }
        }

        public bool CheckSessionIsValid(Guid SessionID)
        {
            using (eShopDbContext context = new eShopDbContext())
            {
                var query = (from u in context.Users
                             where u.SessionId == SessionID &&
                             u.IsActive == true &&
                             u.DateDeleted == null
                             select u).FirstOrDefault();
                return query != null;
            }
        }
    }

}
