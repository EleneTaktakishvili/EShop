using eShop.DomainModel.ValueObjects;
using System;

namespace eShop.DomainModel.Entity
{
    public class RoleEntity : Base
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
