using CKPaymentGateway.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CKPaymentGateway.Http
{
    public class HttpBank
    {
        private readonly HttpClient httpclient;

        public HttpBank(HttpClient _httpclient)
        {
            httpclient = _httpclient;
        }

        public async Task<ResultPaymentDTO> Post(string uri, PaymentGatewayDTO data)
        {
            string json = JsonConvert.SerializeObject(data);
            StringContent content = new StringContent(json, System.Text.Encoding.UTF8, "application/json"); 

            var res = await httpclient.PostAsync(uri, content);

            string str = "" + res.Content + " : " + res.StatusCode;

            res.EnsureSuccessStatusCode();

            string responseBody=await res.Content.ReadAsStringAsync();

            ResultPaymentDTO ret = new()
            {
                Message = responseBody,
                Operation = new Guid()
            };

            return ret;
        }
    }
}
