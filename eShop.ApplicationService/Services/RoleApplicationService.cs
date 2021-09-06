using eShop.ApplicationService.ServiceInterfaces;
using eShop.DataTransferObject.DTOModels;
using eShop.DomainModel.Entity;
using eShop.DomainService.ServiceInterfaces;
using System.Collections.Generic;


namespace eShop.ApplicationService.Services
{
    public class RoleApplicationService : IRoleApplicationService
    {

        private IRoleDomainService _RoleDomainService;

        public RoleApplicationService(IRoleDomainService RoleDomainService)
        {
            _RoleDomainService = RoleDomainService;
        }
        public ICollection<RoleDTO> GetAll()
        {
            ICollection<RoleDTO> roleDTO = new List<RoleDTO>();
            var list = _RoleDomainService.GetAll();

            foreach (var item in list)
            {
                roleDTO.Add(new RoleDTO
                {
                    Id = item.Id,
                    Name = item.Name,
                    DateCreated = item.DateCreated,
                    DateChanged = item.DateChanged,
                    DateDeleted = item.DateDeleted

                });
            }

            return roleDTO;
        }
    }
}
