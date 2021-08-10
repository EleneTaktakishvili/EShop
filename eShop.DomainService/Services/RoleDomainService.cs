using eShop.DomainModel.Entity;
using eShop.DomainService.RepositoriInterfaces;
using eShop.DomainService.ServiceInterfaces;
using System.Collections.Generic;


namespace eShop.DomainService.Services
{
    public class RoleDomainService : IRoleDomainService
    {
        private IRoleRepository _RoleRepository;

        public RoleDomainService(IRoleRepository RoleRepository)
        {
            _RoleRepository = RoleRepository;
        }

        public ICollection<RoleEntity> GetAll()
        {
            return _RoleRepository.GetAll();
        }
    }
}
