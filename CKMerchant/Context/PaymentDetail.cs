using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CKMerchant.Context
{
    public class PaymentDetail
    {
        [Key]
        public int OrderDetailId { get; set; }
        public Guid BankIdentifier { get; set; }
        public string Status { get; set; }
        public DateTime DateOrder { get; set; }
        public string Description { get; set; }
        public string Product { get; set; }
        [Column(TypeName="decimal(12,2)")]
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
