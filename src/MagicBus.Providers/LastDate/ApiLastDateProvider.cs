using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using MagicBus.Repository;
using Newtonsoft.Json;

namespace MagicBus.Providers.LastDate
{
    public class ApiLastdateProvider : ILastDateProvider
    {
        private HttpClient client;
        private string _url;

        public ApiLastdateProvider(IOptions<ApplicationSettings> options)
        {
            _url = options.Value.BaseApiUrl + "/lastdate";
            client = new HttpClient();
            client.BaseAddress = new Uri(_url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<DateTime> GetLastDate()
        {
            string responseData = string.Empty;
            HttpResponseMessage responseMessage = await client.GetAsync(_url);
            if (responseMessage.IsSuccessStatusCode)
            {
                responseData = await responseMessage.Content.ReadAsStringAsync();
            }

            return JsonConvert.DeserializeObject<DateTime>(responseData);
        }
    }
}