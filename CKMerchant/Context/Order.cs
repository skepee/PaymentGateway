using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CKMerchant.Context
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public string Status { get; set; }
        public DateTime DateOrder { get; set; }
        public string Description { get; set; }
        public int CustomerId { get; set; }
    }
}
