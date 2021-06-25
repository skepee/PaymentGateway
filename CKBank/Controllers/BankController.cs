using CKBank.Model;
using CKBank.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CKBank.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class BankController : ControllerBase
    {
        private readonly IBankRepository myBankRepository;

        public BankController(IBankRepository _myBankRepository)
        {
            myBankRepository = _myBankRepository;
        }

        [HttpPost("BankTransaction")]
        public async Task<ResultPaymentDTO> BankPayment([FromBody] PaymentGatewayDTO Payment)
        {
            return await myBankRepository.BankPayment(Payment);
        }
    }
}
