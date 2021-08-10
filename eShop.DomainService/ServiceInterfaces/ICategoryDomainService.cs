using eShop.DomainModel.Entity;
using System;
using System.Collections.Generic;

namespace eShop.DomainService.ServiceInterfaces
{
    public interface ICategoryDomainService
    {
        ICollection<CategoryEntity> GetAll();
        CategoryEntity GetCategory(Guid Id);
        bool SaveUpDate(CategoryEntity entity);
        bool DeleteCategory(Guid Id);
    }
}
