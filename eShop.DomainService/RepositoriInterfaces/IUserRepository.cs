using eShop.DomainModel.Entity;
using System;
using System.Collections.Generic;

namespace eShop.DomainService.RepositoriInterfaces
{
    public interface IUserRepository
    {
        ICollection<UserEntity> GetAll();
        bool Login(UserEntity User);

        bool CheckSessionIsValid(Guid SessionID);
    }
}
