using eShop.DomainModel.Entity;
using eShop.DomainService.RepositoriInterfaces;
using eShop.DomainService.ServiceInterfaces;
using eShop.Utility;
using System;
using System.Collections.Generic;

namespace eShop.DomainService.Services
{
    public class UserDomainService : IUserDomainService
    {
        private IUserRepository _UserRepository;

        public UserDomainService(IUserRepository UserRepository)
        {
            _UserRepository = UserRepository;
        }

        public ICollection<UserEntity> GetAll()
        {
            return _UserRepository.GetAll();
        }

        public List<string> Login(UserEntity User)
        {
            List<string> ValidationResponse = new List<string>();
            ValidationResponse = User.IsValid(UserValidationType.Login);
            if (ValidationResponse.Count == 0)
            {
                if (!_UserRepository.Login(User.Get(UserOperationType.Login)))
                {
                    return new List<string>() { "Email-Password_Activate_Not_Valid" };
                }
                return ValidationResponse;
            }
            else
            {
                return ValidationResponse;
            }

        }


        public bool CheckSessionIsValid(Guid SessionID)
        {
            return _UserRepository.CheckSessionIsValid(SessionID);
        }

        public List<string> Registration(UserEntity User)
        {
            List<string> ValidationResponse = new List<string>();

            ValidationResponse = User.IsValid(UserValidationType.Registration);
            if (ValidationResponse.Count == 0)
            {
                List<string> status = _UserRepository.Registration(User);
               
                return status;
            }
            else
            {
                return ValidationResponse;
            }
        }
        public ICollection<UserAddressEntity> GetUserAddress(Guid UserId)
        {
            return _UserRepository.GetUserAddress(UserId);
        }
    }
}
