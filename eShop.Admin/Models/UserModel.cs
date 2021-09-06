using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace eShop.Admin.Models
{
    public class UserModel : BaseModel
    {
        public Guid Id { get; set; }

        [DisplayName("სტატუსი")]
        public bool IsActive { get; set; }

        [DisplayName("სახელი")]
        public string FirtsName { get; set; }

        [DisplayName("გვარი")]
        public string LastName { get; set; }

        [DisplayName("ელ.ფოსტა")]
        public string Email { get; set; }
        public Guid RoleId { get; set; }

        [DisplayName("როლი")]
        public string RoleName { get; set; }
    }
}
