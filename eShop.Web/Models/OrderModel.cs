using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eShop.Web.Models
{
    public class OrderModel 
    {
        public Guid Id { get; set; }
        public string OrderStatus { get; set; }
        public decimal TotalPrice { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateCreated { get; set; }

    }

    public class OrdeDetailModel 
    {
        public Guid Id { get; set; }
        public string ProductName { get; set; }
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }
    }
   
}
