using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.DataTransferObject.DTOModels
{
    public class UserAddressDTO
    {
        public Guid ID { get; set; }
        public Guid UserId { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
    }
}
