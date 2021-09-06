using eShop.ApplicationService.ServiceInterfaces;
using eShop.DataTransferObject.DTOModels;
using eShop.DomainModel.Entity;
using eShop.DomainService.ServiceInterfaces;
using System;
using System.Collections.Generic;


namespace eShop.ApplicationService.Services
{
    public class CategoryApplicationService : ICategoryApplicationService
    {
        private ICategoryDomainService _CategoryDomainService;
      
        public CategoryApplicationService(ICategoryDomainService CategoryDomainService)
        {
            _CategoryDomainService = CategoryDomainService;           
        }     

        public ICollection<CategoryDTO> GetAll()
        {
            ICollection<CategoryDTO> categoryDTO = new List<CategoryDTO>();
            var list = _CategoryDomainService.GetAll();

            foreach (var item in list)
            {
                categoryDTO.Add(new CategoryDTO
                {
                    Id = item.Id,
                    Name = item.Name,
                    DateCreated = item.DateCreated,
                    DateChanged = item.DateChanged,
                    DateDeleted = item.DateDeleted

                });
            }
            return categoryDTO;
        }

        public CategoryDTO GetCategory(Guid Id)
        {
            CategoryDTO categoryDTO = new CategoryDTO();

            var item = _CategoryDomainService.GetCategory(Id);

            categoryDTO.Id = item.Id;
            categoryDTO.Name = item.Name;
            categoryDTO.DateCreated = item.DateCreated;
            categoryDTO.DateChanged = item.DateChanged;
            categoryDTO.DateDeleted = item.DateDeleted;

            return categoryDTO;
        }

        public bool SaveUpDate(CategoryDTO categoryDTO)
        {
            CategoryEntity categoryEntity = new CategoryEntity();
            categoryEntity.Id = categoryDTO.Id;
            categoryEntity.Name = categoryDTO.Name;
            categoryEntity.DateCreated = categoryEntity.DateCreated;
            categoryEntity.DateChanged = categoryDTO.DateChanged;
            categoryEntity.DateDeleted = categoryDTO.DateDeleted;

            return _CategoryDomainService.SaveUpDate(categoryEntity);            
        }
        public bool DeleteCategory(Guid Id)
        {
            return _CategoryDomainService.DeleteCategory(Id);
        }
    }
}
