using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CK_Merchant.Context
{
    public class OrderPaymentDetail
    {
        [Key]
        public int OrderPaymentDetailId { get; set; }
        public string Product { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
