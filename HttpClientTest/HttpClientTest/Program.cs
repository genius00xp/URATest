using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace HttpClientSample
{
    class Program
    {
        static HttpClient client = new HttpClient();

        static async Task<Object> GetResultAsync(string path)
        {
            Object result = null;
            client.DefaultRequestHeaders.Add("AccessKey", "<Replace-Your-Access-Key");
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                //result = await response.Content.ReadAsAsync<Object>();
                result = await response.Content.ReadAsStringAsync(); //Uncomment this line to view the HTML response return from URA
            }
            return result;
        }

        static void Main()
        {
            RunAsync().GetAwaiter().GetResult();
        }

        static async Task RunAsync()
        {
           try
            {
                var product = await GetResultAsync("https://www.ura.gov.sg/uraDataService/insertNewToken.action");

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }
    }
}