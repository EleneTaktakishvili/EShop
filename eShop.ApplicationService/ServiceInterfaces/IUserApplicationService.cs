using eShop.DataTransferObject.DTOModels;
using System;
using System.Collections.Generic;

namespace eShop.ApplicationService.ServiceInterfaces
{
    public interface IUserApplicationService
    {
        ICollection<UserDTO> GetAll();
        UserAuthResponseDTO Registration(UserDTO User);
        UserAuthResponseDTO Login(LoginDTO User);
        ICollection<UserAddressDTO> GetUserAddress(Guid UserId);
    }
}
