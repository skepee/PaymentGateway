using CKBank.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CKBank.Service
{
    public class BankRepository : IBankRepository
    {
        public Task<ResultPaymentDTO> BankPayment(PaymentGatewayDTO Payment)
        {
            //card validation 
            if (!Helper.checkLuhn(Payment.CardNumber))
            {
                return Task.FromResult(new ResultPaymentDTO
                {
                    Message = "Card not valid."
                });
            }

            if (DateTime.Now > new DateTime(Payment.ExpiryYear, Payment.ExpiryMonth, 1))
            {
                return Task.FromResult(new ResultPaymentDTO
                {
                    Message = "Card Expired."
                });
            }

            //simulate payment
            // ---
            return Task.FromResult(new ResultPaymentDTO
            {
                Operation = Guid.NewGuid(),
                Message = "OK"
            });
        }
    }
    };

