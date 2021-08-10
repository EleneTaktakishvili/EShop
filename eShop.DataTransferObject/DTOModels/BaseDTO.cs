using System;

namespace eShop.DataTransferObject.DTOModels
{
    public class BaseDTO
    {
        public DateTime DateCreated { get; set; }
        public DateTime? DateChanged { get; set; }
        public DateTime? DateDeleted { get; set; }
    }
}
