using eShop.DomainModel.Entity;
using eShop.DomainService.RepositoriInterfaces;
using eShop.DomainService.ServiceInterfaces;
using System;
using System.Collections.Generic;

namespace eShop.DomainService.Services
{
    public class CategoryDomainService : ICategoryDomainService
    {
        private ICategoryRepository _CategoryRepository;

        public CategoryDomainService(ICategoryRepository CategoryRepository)
        {
            _CategoryRepository = CategoryRepository;
        }
        public ICollection<CategoryEntity> GetAll()
        {
            return _CategoryRepository.GetAll();
        }
        public CategoryEntity GetCategory(Guid Id)
        {
            return _CategoryRepository.GetCategory(Id);
        }
        public bool SaveUpDate(CategoryEntity entity)
        {
            return _CategoryRepository.SaveUpDate(entity);
        }
        public bool DeleteCategory(Guid Id)
        {
            return _CategoryRepository.DeleteCategory(Id);
        }
    }
}
