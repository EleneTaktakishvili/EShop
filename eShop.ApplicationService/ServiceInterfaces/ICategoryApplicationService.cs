using eShop.DataTransferObject.DTOModels;
using System;
using System.Collections.Generic;


namespace eShop.ApplicationService.ServiceInterfaces
{
    public interface ICategoryApplicationService
    {
        ICollection<CategoryDTO> GetAll();
        CategoryDTO GetCategory(Guid Id);
        bool SaveUpDate(CategoryDTO categoryDTO);
        bool DeleteCategory(Guid Id);
    }
}
