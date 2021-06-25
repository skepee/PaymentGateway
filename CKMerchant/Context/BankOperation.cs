using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BankGateway.Context
{
    public class BankOperation
    {
        [Key]
        public Guid BankOperationId { get; set; }
        public string Status { get; set; }
        public int OrderId { get; set; }
    }
}
