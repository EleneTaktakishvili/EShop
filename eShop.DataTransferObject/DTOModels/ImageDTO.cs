using System;

namespace eShop.DataTransferObject.DTOModels
{
    public class ImageDTO
    {
        public Guid Id { get; set; }
        public string ImagePath { get; set; }
        public bool IsMain { get; set; }
    }
}
