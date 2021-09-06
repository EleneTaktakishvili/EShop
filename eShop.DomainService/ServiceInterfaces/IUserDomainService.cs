using eShop.DomainModel.Entity;
using System;
using System.Collections.Generic;


namespace eShop.DomainService.ServiceInterfaces
{
    public interface IUserDomainService
    {
        ICollection<UserEntity> GetAll();
        List<string> Registration(UserEntity User);
        List<string> Login(UserEntity User);
        bool CheckSessionIsValid(Guid SessionID);
        ICollection<UserAddressEntity> GetUserAddress(Guid UserId);
    }
}
