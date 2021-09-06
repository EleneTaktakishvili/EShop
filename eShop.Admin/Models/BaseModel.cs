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

        [DataType(DataType.Date)]
        [DisplayName("რედაქტირების თარიღი")]
        public DateTime? DateChanged { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("წაშლის თარიღი")]
        public DateTime? DateDeleted { get; set; }
    }
}
