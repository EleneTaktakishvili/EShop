using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.DataTransferObject.DTOModels
{
    public class UserAuthResponseDTO : ExceptionDTO
    {
        public Guid? SessionID { get; set; }
    }
  
}
