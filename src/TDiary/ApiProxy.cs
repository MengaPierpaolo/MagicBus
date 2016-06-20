using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using TDiary.Model;
using TDiary.Providers.ViewModel;
using TDiary.Providers.ViewModel.Model;
using TDiary.Repository;
using TDiary.Service;

namespace TDiary
{
    public class ApiProxy<T, U> where T : DiaryItem where U : ActivityViewModel
    {
        private readonly IViewModelProvider<T, U> _viewModelProvider;
        private readonly HttpClient client;
        private string baseUrl;

        public ApiProxy(IOptions<DatabaseSettings> options, IViewModelProvider<T, U> viewModelProvider)
        {
            _viewModelProvider = viewModelProvider;
            baseUrl = options.Value.BaseApiUrl;

            client = new HttpClient();
            client.BaseAddress = new Uri(baseUrl + '/' + typeof(T).Name + '/');
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            //convert Enums to Strings (instead of Integer) globally
            JsonConvert.DefaultSettings = (() =>
            {
                var settings = new JsonSerializerSettings();
                settings.Converters.Add(new Newtonsoft.Json.Converters.StringEnumConverter());
                return settings;
            });
        }

        public void SetUrl(string url)
        {
            client.BaseAddress = new Uri(baseUrl + url);
        }

        public async Task<IEnumerable<RecentExperienceViewModel>> GetRecent()
        {
            HttpResponseMessage responseMessage = await client.GetAsync(client.BaseAddress);
            if (responseMessage.IsSuccessStatusCode)
            {
                var responseData = await responseMessage.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<RecentExperienceViewModel>>(responseData);
            }

            // TODO: log non-happy path
            return new List<RecentExperienceViewModel>();
        }

        public async Task Add(DiaryItem item)
        {
            await client.PostAsync(client.BaseAddress, GetPostContent(item));
        }

        public async Task SaveChanges(DiaryItem item)
        {
            await client.PutAsync(client.BaseAddress.ToString() + item.Id, GetPostContent(item));
        }

        private HttpContent GetPostContent(DiaryItem item)
        {
            var jsonString = JsonConvert.SerializeObject(item);
            return new StringContent(jsonString, Encoding.UTF8, "application/json");
        }

        public async Task<ActivityViewModel> GetEditViewModel(int id)
        {
            HttpResponseMessage responseMessage = await client.GetAsync(client.BaseAddress.ToString() + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var responseData = await responseMessage.Content.ReadAsStringAsync();
                var vm = JsonConvert.DeserializeObject<U>(responseData);
                return RefreshEditViewModel(vm);
            }
            return default(U);
        }

        public async Task Delete(int id)
        {
            await client.DeleteAsync(client.BaseAddress.ToString() + id);
        }

        public ActivityViewModel GetAddViewModel()
        {
            return _viewModelProvider.CreateAddViewModel();
        }

        public ActivityViewModel RefreshAddViewModel(ActivityViewModel vm)
        {
            return _viewModelProvider.RefreshAddViewModel(vm as U);
        }

        public ActivityViewModel RefreshEditViewModel(ActivityViewModel vm)
        {
            return _viewModelProvider.RefreshEditViewModel(vm as U);
        }

        public async Task PromoteActivity(int activityId)
        {
            var jsonString = JsonConvert.SerializeObject("Up");
            var x = new StringContent(jsonString, Encoding.UTF8, "application/json");
            await client.PutAsync(client.BaseAddress.ToString() + activityId, x);
        }

        public async Task DemoteActivity(int activityId)
        {
            var jsonString = JsonConvert.SerializeObject("Down");
            var x = new StringContent(jsonString, Encoding.UTF8, "application/json");
            await client.PutAsync(client.BaseAddress.ToString() + activityId, x);
        }
    }
}