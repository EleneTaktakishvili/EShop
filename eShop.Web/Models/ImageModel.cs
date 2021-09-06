using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eShop.Web.Models
{
    public class ImageModel
    {
        public Guid Id { get; set; }
        public string ImagePath { get; set; }
        public bool IsMain { get; set; }
    }
}
