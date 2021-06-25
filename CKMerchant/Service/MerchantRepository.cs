using CKMerchant.Context;
using CKMerchant.Http;
using CKMerchant.Model;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CKMerchant.Service
{
    public class MerchantRepository : IMerchantRepository
    {
        private readonly CKMerchantContext bankGatewayContext;
        private readonly HttpPaymentGateway httpPaymentGateway;

        public MerchantRepository(CKMerchantContext _bankGatewayContext, HttpPaymentGateway _httpPaymentGateway)
        {
            bankGatewayContext = _bankGatewayContext;
            httpPaymentGateway = _httpPaymentGateway;
        }


        public Task<PaymentDetailDTO> GetPaymentDetails(Guid bankIdentifier)
        {
            string sql = "EXECUTE PaymentDetail @bankIdentifier";

            SqlParameter parms = new() { ParameterName = "@bankIdentifier", Value = bankIdentifier };

            var payment = bankGatewayContext.PaymentDetails.FromSqlRaw(sql, parms).AsEnumerable().ToList();

            return Task.FromResult(new PaymentDetailDTO
            {
                BankIdentifier = payment.FirstOrDefault().BankIdentifier,
                DateOrder = payment.FirstOrDefault().DateOrder,
                Description = payment.FirstOrDefault().Description,
                Status = payment.FirstOrDefault().Status,
                Details =payment.Select(x => new OrderDetail
                {
                    Price = x.Price,
                    Product = x.Product,
                    Quantity = x.Quantity
                }),               
                Total = payment.Sum(x => x.Quantity * x.Price)
            });
        }

        public Task<String> Payment(PaymentDTO payment)
        {
            try
            {
                //BankPayment
                //string urlPayment = $"{payment.HolderName}|" +
                //                   $"{payment.CardNumber}|" +
                //                   $"{payment.ExpiryMonth}|" +
                //                   $"{payment.ExpiryYear}|" +
                //                   $"{payment.Cvv}";


                PaymentGatewayDTO p = new()
                {
                    HolderName = payment.Gateway.HolderName,
                    CardNumber = payment.Gateway.CardNumber,
                    ExpiryMonth = payment.Gateway.ExpiryMonth,
                    ExpiryYear = payment.Gateway.ExpiryYear,
                    Cvv = payment.Gateway.Cvv,
                    Currency=payment.Gateway.Currency,
                    Total=payment.Gateway.Total
                };

                var res = httpPaymentGateway.Post("/api/PaymentGateway/Payment", p);




                //Order order = new()
                //{
                //    CustomerId = payment.CustomerId,
                //    DateOrder = DateTime.Now,
                //    Description = payment.OrderDescription,
                //    Status = string.Empty
                //};

                bankGatewayContext.Order.Add(payment.Order);
                bankGatewayContext.SaveChanges();

                var l = new List<OrderDetail>();

                foreach (var item in payment.OrderDetails)
                {
                    l.Add(new OrderDetail
                    {
                        Price = item.Price,
                        Product = item.Product,
                        Quantity = item.Quantity,
                        OrderId = payment.Order.OrderId
                    });
                };

                bankGatewayContext.OrderDetail.AddRange(l);
                bankGatewayContext.SaveChanges();

                return Task.FromResult("OK");
            }
            catch (Exception ex)
            {
                return Task.FromResult(ex.Message);
            }
        }     
    }
    };

