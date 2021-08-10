using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace eShop.Admin.Models
{
    public class BaseModel
    {
        [DataType(DataType.Date)]
        [DisplayName("დამატების თარიღი")]
        public DateTime DateCreated { get; set; }
        public DateTime? DateChanged { get; set; }
        public DateTime? DateDeleted { get; set; }
    }
}
