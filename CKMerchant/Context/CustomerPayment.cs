using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CKMerchant.Context
{
    public class CustomerPayment
    {
        [Key]
        public int CustomerPaymentId{get;set;}
        public string CardNumber { get; set;}
        public int ExpiryMonth { get; set; }
        public int ExpiryYear { get; set; }
        public string Currency { get; set; }
        public int Cvv { get; set; }
    }
}
