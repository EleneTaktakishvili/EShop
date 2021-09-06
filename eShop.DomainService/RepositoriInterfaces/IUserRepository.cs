using eShop.DomainModel.Entity;
using System;
using System.Collections.Generic;

namespace eShop.DomainService.RepositoriInterfaces
{
    public interface IUserRepository
    {
        ICollection<UserEntity> GetAll();
        List<string> Registration(UserEntity User);
        bool Login(UserEntity User);
        bool CheckSessionIsValid(Guid SessionID);
        ICollection<UserAddressEntity> GetUserAddress(Guid UserId);
    }
}
