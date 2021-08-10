using eShop.DataTransferObject.DTOModels;
using System.Collections.Generic;

namespace eShop.ApplicationService.ServiceInterfaces
{
    public interface IRoleApplicationService
    {
        ICollection<RoleDTO> GetAll();
    }
}
