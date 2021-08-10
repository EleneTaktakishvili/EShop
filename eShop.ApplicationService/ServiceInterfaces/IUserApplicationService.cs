using eShop.DataTransferObject.DTOModels;
using System.Collections.Generic;

namespace eShop.ApplicationService.ServiceInterfaces
{
    public interface IUserApplicationService
    {
        ICollection<UserDTO> GetAll();
        UserAuthResponseDTO Login(LoginDTO User);
    }
}
