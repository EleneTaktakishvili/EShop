using eShop.DataBaseRepository.Db;
using eShop.DataBaseRepository.Db.Models;
using eShop.DomainModel.Entity;
using eShop.DomainService.RepositoriInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace eShop.DataBaseRepository.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        public ICollection<RoleEntity> GetAll()
        {
            ICollection<RoleEntity> roleEntity = new List<RoleEntity>();

            //using (eShopDbContext context = new eShopDbContext())
            //{
            //    roleEntity = (from role in context.Roles
            //                  where role.DateDeleted == null
            //                  select new RoleEntity
            //                  {
            //                      Id = role.Id,
            //                      Name = role.Name,
            //                      DateCreated = role.DateCreated,
            //                      DateChanged = role.DateChanged,
            //                      DateDeleted = role.DateDeleted
            //                  }).ToList();
            //}
            return roleEntity;
        }

    }
}
