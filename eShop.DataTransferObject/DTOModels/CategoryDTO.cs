using System;

namespace eShop.DataTransferObject.DTOModels
{
    public class CategoryDTO : BaseDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

    }
}
