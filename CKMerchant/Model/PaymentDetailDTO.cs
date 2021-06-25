using CKMerchant.Context;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CKMerchant.Model
{
    public class PaymentDetailDTO
    {
        public Guid BankIdentifier { get; set; }
        public string Status { get; set; }
        public DateTime DateOrder { get; set; }
        public string Description { get; set; }
        public IEnumerable<OrderDetail> Details { get; set; }
        public decimal Total { get; set; }
    }
}
