using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Models.SonarQube;


namespace Business_Util
{
    public class ConsumeRest
    {
        public async Task GetAsync(string url, string type) 
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(url))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    //var reservationList = JsonConvert.DeserializeObject<"sds",typeof("type.GetType().FullName")>(apiResponse);
                }
            }
            return ;
        }

        public async Task<string> HTTP_GET(string targetUrl, int pag, string SonarToken)
        {
            Console.WriteLine("GET: + " + targetUrl + pag);

            // ... Use HttpClient.            
            HttpClient client = new HttpClient();

            var byteArray = Encoding.ASCII.GetBytes(SonarToken);
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", "NTY5NGVhN2JmMDA1ZDFiYjM4ZTk4ZjkyMzRmOGI4MGMwODg1MzE0NDo=");//Convert.ToBase64String(byteArray));

            HttpResponseMessage response = await client.GetAsync(targetUrl + pag);
            HttpContent content = response.Content;

            // ... Check Status Code                                
            Console.WriteLine("Response StatusCode: " + (int)response.StatusCode);
            if ((int)response.StatusCode == 200)
            {
                var result = await content.ReadAsStringAsync();

                return result;
            }
            else
                return null;
        }
    }
}
