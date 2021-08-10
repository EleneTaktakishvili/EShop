using System;

namespace eShop.DataTransferObject.DTOModels
{
    public class RoleDTO : BaseDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
