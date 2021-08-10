using System;
using System.ComponentModel;

namespace eShop.Admin.Models
{
    public class RoleModel : BaseModel
    {
        public Guid Id { get; set; }

        [DisplayName("დასახელება")]
        public string Name { get; set; }
    }
}
