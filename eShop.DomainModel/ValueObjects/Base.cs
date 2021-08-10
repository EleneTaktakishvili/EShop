using System;

namespace eShop.DomainModel.ValueObjects
{
    public class Base
    {
        public DateTime DateCreated { get; set; }
        public DateTime? DateChanged { get; set; }
        public DateTime? DateDeleted { get; set; }
    }
}
