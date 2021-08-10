using eShop.DomainModel.Entity;
using System;
using System.Collections.Generic;

namespace eShop.DomainService.RepositoriInterfaces
{
    public interface ICategoryRepository
    {
        ICollection<CategoryEntity> GetAll();
        CategoryEntity GetCategory(Guid Id);
        bool SaveUpDate(CategoryEntity entity);
        bool DeleteCategory(Guid Id);
    }
}
