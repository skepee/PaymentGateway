using CKMerchant.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CKMerchant.Context
{
    public class CKMerchantContext: DbContext
    {
        protected DbContextOptions<CKMerchantContext> ContextOptions { get; }

        public CKMerchantContext(DbContextOptions<CKMerchantContext> options): base(options)
        {
            ContextOptions= options;        
        }

        public DbSet<Order> Order { get; set; }
        public DbSet<OrderDetail> OrderDetail { get; set; }
        public DbSet<PaymentDetail> PaymentDetails { get; set; }
    }
}
