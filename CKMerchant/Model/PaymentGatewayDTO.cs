using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CKMerchant.Model
{
    public class PaymentGatewayDTO
    {
        public string HolderName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string CardNumber { get; set; }
        public int ExpiryMonth { get; set; }
        public int ExpiryYear { get; set; }
        public int Cvv { get; set; }
        public decimal Total { get; set; }
        public string Currency { get; set; }
    }
}
