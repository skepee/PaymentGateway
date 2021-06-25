using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CKPaymentGateway.Service
{
    public interface IPaymentGatewayRepository
    {
        public Task<string> Payment();

    }
}
