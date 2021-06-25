using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CK_Merchant.Context
{
    public class OrderPayment
    {
        [Key]
        public int OrderId { get; set; }
        [NotMapped]
        public int CustomerId { get; set; }
        public string Status { get; set; }
        public DateTime DateOrder { get; set; }
        public string Description { get; set; }
    }
}
