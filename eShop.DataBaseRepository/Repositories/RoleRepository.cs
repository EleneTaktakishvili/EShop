using eShop.DataBaseRepository.Db;
using eShop.DataBaseRepository.Db.Models;
using eShop.DomainModel.Entity;
using eShop.DomainService.RepositoriInterfaces;
using System.Collections.Generic;
using System.Linq;

namespace eShop.DataBaseRepository.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        public ICollection<RoleEntity> GetAll()
        {
            ICollection<Roles> roleDb = new List<Roles>();
            ICollection<RoleEntity> roleEntity = new List<RoleEntity>();

            using (eShopDbContext context = new eShopDbContext())
            {
                roleDb = (from role in context.Roles
                          select role).ToList();

                foreach (var item in roleDb)
                {
                    roleEntity.Add(new RoleEntity
                    {
                        Id = item.Id,
                        Name = item.Name,
                        DateCreated = item.DateCreated,
                        DateChanged = item.DateChanged,
                        DateDeleted = item.DateDeleted

                    });
                }
            }
            return roleEntity;
        }
    }
}
