using eShop.ApplicationService.ServiceInterfaces;
using eShop.DataTransferObject.DTOModels;
using eShop.DomainModel.Entity;
using eShop.DomainService.ServiceInterfaces;
using System;
using System.Collections.Generic;


namespace eShop.ApplicationService.Services
{
    public class UserApplicationService : IUserApplicationService
    {
        private IUserDomainService _UserDomainService;

        public UserApplicationService(IUserDomainService UserDomainService)
        {
            _UserDomainService = UserDomainService;
        }
        public ICollection<UserDTO> GetAll()
        {

            ICollection<UserDTO> userDTO = new List<UserDTO>();
            var list = _UserDomainService.GetAll();

            foreach (var item in list)
            {
                userDTO.Add(new UserDTO
                {
                    Id = item.Id,
                    FirtsName = item.FirtsName,
                    LastName = item.LastName,
                    Email = item.Email,
                    IsActive = item.IsActive,
                    RoleId = item.RoleId,
                    RoleName = item.RoleName

                });
            }
            return userDTO;
        }

        public UserAuthResponseDTO Login(LoginDTO User)
        {
            UserEntity user = new UserEntity();
            user.Email = User.Email;
            user.PasswordHash = User.PasswordHash;

            return new UserAuthResponseDTO()
            {
                Messages = _UserDomainService.Login(user),
                SessionID = user.SessionId
            };
        }

        public ICollection<UserAddressDTO> GetUserAddress(Guid UserId)
        {
            ICollection<UserAddressDTO> userAddressDTO = new List<UserAddressDTO>();
            var list = _UserDomainService.GetUserAddress(UserId);

            foreach (var item in list)
            {
                userAddressDTO.Add(new UserAddressDTO
                {
                    ID = item.ID,
                    UserId = item.UserId,
                    City = item.City,
                    Address = item.Address
                });
            }
            return userAddressDTO;
        }

        public UserAuthResponseDTO Registration(UserDTO User)
        {
            UserEntity user = new UserEntity();
            user.Email = User.Email;
            user.FirtsName = User.FirtsName;
            user.LastName = User.LastName;
            user.PasswordHash = User.PasswordHash;
            user.RepeatPasswordHash = User.RepeatPasswordHash;

            return new UserAuthResponseDTO()
            {
                Messages = _UserDomainService.Registration(user)
               
            };
           
        }
    }
}
