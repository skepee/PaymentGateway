using CKMerchant.Context;
using CKMerchant.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CKMerchant.Service
{
    public interface IMerchantRepository
    {
        public Task<PaymentDetailDTO> GetPaymentDetails(Guid BankIdentifier);
        public Task<string> Payment(PaymentDTO payment);
    }
}
