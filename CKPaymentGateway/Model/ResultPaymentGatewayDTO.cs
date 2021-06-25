using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CKPaymentGateway.Model
{
    public class ResultPaymentGatewayDTO
    {
        public Guid UniqueIdentifier { get; set; }
        public string GatewayMessage { get; set; }
        public string BankMessage { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public string CardHolder { get; set; }
        public string CardNumberPartiallyMasked { get; set; }
    }
}
