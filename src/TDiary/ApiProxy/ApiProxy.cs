using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using TDiary.Model;
using TDiary.Providers.ViewModel.Model;
using TDiary.Repository;

namespace TDiary
{
    public class ApiProxy : IApiProxy
    {
        private readonly HttpClient client;
        private string baseUrl;

        public ApiProxy(IOptions<ApplicationSettings> options)
        {
            baseUrl = options.Value.BaseApiUrl;

            client = new HttpClient();
            client.BaseAddress = new Uri(baseUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task Add(DiaryItem item)
        {
            await client.PostAsync(GetItemAddress(item.GetType()), GetPostContent(item));
        }

        public async Task<IEnumerable<ExperienceViewModel>> GetRecent()
        {
            HttpResponseMessage responseMessage = await client.GetAsync(client.BaseAddress);
            if (responseMessage.IsSuccessStatusCode)
            {
                var responseData = await responseMessage.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<ExperienceViewModel>>(responseData);
            }

            // TODO: log non-happy path
            return default(List<ExperienceViewModel>);
        }

        public void SetPath(string url)
        {
            client.BaseAddress = new Uri(baseUrl + url);
        }

        public async Task Save(DiaryItem item)
        {
            await client.PutAsync(GetItemAddress(item.GetType()) + item.Id, GetPostContent(item));
        }

        public async Task<T> Get<T>(int id) where T : ActivityViewModel
        {
            HttpResponseMessage responseMessage = await client.GetAsync(GetItemAddress(typeof(T)) + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var responseData = await responseMessage.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(responseData);
            }
            return default(T);
        }

        public async Task Delete<T>(int id) where T : DiaryItem
        {
            await client.DeleteAsync(GetItemAddress(typeof(T)) + id);
        }

        public async Task PromoteActivity(int activityId)
        {
            await client.PutAsync(client.BaseAddress.ToString() + activityId,
                GetPromotionContent(directionIsUp: true));
        }

        public async Task DemoteActivity(int activityId)
        {
            await client.PutAsync(client.BaseAddress.ToString() + activityId,
                GetPromotionContent(directionIsUp: false));
        }

        private string GetItemAddress(Type item)
        {
            return string.Format("{0}/{1}/", client.BaseAddress, item.Name.Replace("ViewModel",string.Empty));
        }

        private HttpContent GetPostContent(DiaryItem item)
        {
            var jsonString = JsonConvert.SerializeObject(item);
            return new StringContent(jsonString, Encoding.UTF8, "application/json");
        }

        private HttpContent GetPromotionContent(bool directionIsUp)
        {
            var jsonString = JsonConvert.SerializeObject(directionIsUp ? "Up" : "Down");
            return new StringContent(jsonString, Encoding.UTF8, "application/json");
        }

        public async Task<IEnumerable<ExperienceViewModel>> GetAllByPage(int pageSize, int page = 0)
        {
            HttpResponseMessage responseMessage = await client.GetAsync(client.BaseAddress + "/pagenumber/" + page.ToString());
            if (responseMessage.IsSuccessStatusCode)
            {
                var responseData = await responseMessage.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<ExperienceViewModel>>(responseData);
            }

            // TODO: log non-happy path
            return default(List<ExperienceViewModel>);
        }
    }
}