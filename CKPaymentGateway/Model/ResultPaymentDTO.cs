using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CKPaymentGateway.Model
{
    public class ResultPaymentDTO
    {
        public Guid Operation { get; set; }
        public string Message { get; set; }
    }
}
