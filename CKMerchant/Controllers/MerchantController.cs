using CKMerchant.Context;
using CKMerchant.Model;
using CKMerchant.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CKMerchant.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class MerchantController : ControllerBase
    {
        private readonly IMerchantRepository myBankGatewayRepository;
        private readonly ILogger<MerchantController> logger;

        public MerchantController(IMerchantRepository _myBankGatewayRepository, ILogger<MerchantController> _logger)
        {
            myBankGatewayRepository = _myBankGatewayRepository;
            logger = _logger;
        }

        [HttpGet("PaymentDetails/{bankIdentifier}")]
        public async Task<PaymentDetailDTO> GetPaymentDetails(Guid bankIdentifier)
        {
            logger.LogInformation("GetPayment - CKMerchant.Api");

            return await Task.Run(async () =>
            {
                var res = await myBankGatewayRepository.GetPaymentDetails(bankIdentifier);
                return res;
            });
        }


        [HttpPost("Payment")]
        public async Task Payment([FromBody] PaymentDTO payment)
        {
            logger.LogInformation("Payment - CKMerchant.Api");
            await myBankGatewayRepository.Payment(payment);
        }

    }
}
