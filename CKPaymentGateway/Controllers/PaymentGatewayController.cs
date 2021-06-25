using CKPaymentGateway.Http;
using CKPaymentGateway.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKPaymentGateway.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentGatewayController : ControllerBase
    {
        private readonly HttpBank httpBank;

        public PaymentGatewayController(HttpBank _httpBank)
        {
            httpBank= _httpBank;
        }

        [HttpPost("Payment")]
        public async Task<ResultPaymentGatewayDTO> Payment([FromBody] PaymentGatewayDTO Payment)
        {
            ResultPaymentGatewayDTO res = new()
            {
                Amount = Payment.Amount,
                CardHolder = Payment.CardHolder,
                CardNumberPartiallyMasked = new String('*', Payment.CardNumber.Length - 4) + Payment.CardNumber.Substring(Payment.CardNumber.Length - 4),
                Currency=Payment.Currency
            };
           
            //card validation 
            if (!Helper.checkLuhn(Payment.CardNumber))
            {
                res.GatewayMessage = "Card not valid.";
                return res;
            }

            if (DateTime.Now > new DateTime(Payment.ExpiryYear, Payment.ExpiryMonth, 1))
            {
                res.GatewayMessage = "Card Expired.";
                return res;

            }

            //process payment to bank
            ResultPaymentDTO resBank= await httpBank.Post("/api/Bank/BankTransaction", Payment);
            res.BankMessage = resBank.Message;
            res.UniqueIdentifier = resBank.Operation;

            return res;
        }
    }
}
