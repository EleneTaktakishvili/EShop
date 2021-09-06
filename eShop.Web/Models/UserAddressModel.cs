using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eShop.Web.Models
{
    public class UserAddressModel
    {

        public Guid ID { get; set; }
        public Guid UserId { get; set; }
        public string City { get; set; }
        public string Address { get; set; }       
    }
}
