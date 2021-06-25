using CKMerchant.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CKMerchant.Http
{
    public class HttpPaymentGateway
    {
        private readonly HttpClient httpclient;

        public HttpPaymentGateway(HttpClient _httpclient)
        {
            httpclient = _httpclient;
        }

        //public async Task<ActionResult> Index()
        //{
        //    apiTable table = new apiTable();
        //    table.Name = "Asma Nadeem";
        //    table.Roll = "6655";

        //    string str = "";
        //    string str2 = "";

        //    HttpClient client = new HttpClient();

        //    string json = JsonConvert.SerializeObject(table);

        //    StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

        //    var response = await client.PostAsync("http://YourSite.com/api/apiTables", httpContent);

        //    str = "" + response.Content + " : " + response.StatusCode;

        //    if (response.IsSuccessStatusCode)
        //    {
        //        str2 = "Data Posted";
        //    }

        //    return View();
        //}

        public async Task<string> Post(string uri, PaymentGatewayDTO data)
        {
            string json = JsonConvert.SerializeObject(data);
            StringContent content = new StringContent(json, System.Text.Encoding.UTF8, "application/json"); 

            var res= await httpclient.PostAsync(uri, content);

            string str = "" + res.Content + " : " + res.StatusCode;

            if (res.IsSuccessStatusCode)
            {
                str = "Data Posted";
            }

            return str;
        }
    }
}
