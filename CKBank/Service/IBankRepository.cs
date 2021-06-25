using CKBank.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CKBank.Service
{
    public interface IBankRepository
    {
        public Task<ResultPaymentDTO> BankPayment(PaymentGatewayDTO Payment);
    }
}
