﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.DataTransferObject.DTOModels
{
   public class LoginDTO
    {
        public string Email { get; set; }
        public string PasswordHash { get; set; }
    }
}
