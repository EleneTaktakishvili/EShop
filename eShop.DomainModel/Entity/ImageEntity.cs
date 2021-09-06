using System;

namespace eShop.DomainModel.Entity
{
    public class ImageEntity
    {
        public Guid Id { get; set; }
        public string ImagePath { get; set; }
        public bool IsMain { get; set; }
    }
}
