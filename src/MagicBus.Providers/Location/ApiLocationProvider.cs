using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using MagicBus.Repository;

namespace MagicBus.Providers.Location
{
    public class ApiLocationProvider : ILocationProvider
    {
        private HttpClient client;
        private string _url;

        public ApiLocationProvider(IOptions<ApplicationSettings> options)
        {
            _url = options.Value.BaseApiUrl + "/location";
            client = new HttpClient();
            client.BaseAddress = new Uri(_url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<string> GetLastLocation()
        {
            string responseData = string.Empty;
            HttpResponseMessage responseMessage = await client.GetAsync(_url);
            if (responseMessage.IsSuccessStatusCode)
            {
                responseData = await responseMessage.Content.ReadAsStringAsync();
            }

            return responseData;
        }
    }
}