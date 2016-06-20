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

namespace TDiary
{
    public interface IApiProxy<T, U> where T : DiaryItem where U : ActivityViewModel
    {
        //void AppendUrl(string url);
        Task<IEnumerable<RecentExperienceViewModel>> GetRecent();
        void Add(T item);
        void SaveChanges(T item);
        void Delete(int id);
        U Get(int id);
        ActivityViewModel GetAddViewModel();
        ActivityViewModel RefreshAddViewModel(U vm);
        ActivityViewModel RefreshEditViewModel(U vm);
    }

    public class ApiProxy<T, U> : IApiProxy<DiaryItem, ActivityViewModel> where T : DiaryItem where U : ActivityViewModel
    {
        private IViewModelProvider<T, U> _viewModelProvider;
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

            return null; // TODO: Look at what this should be
        }

        public void Add(DiaryItem item)
        {
            client.PostAsync(client.BaseAddress, GetPostContent(item)).Wait();
        }

        public void SaveChanges(DiaryItem item)
        {
            client.PutAsync(client.BaseAddress.ToString() + item.Id, GetPostContent(item)).Wait();
        }

        private HttpContent GetPostContent(DiaryItem item)
        {
            var jsonString = JsonConvert.SerializeObject(item);
            return new StringContent(jsonString, Encoding.UTF8, "application/json");
        }

        public ActivityViewModel Get(int id)
        {
            HttpResponseMessage responseMessage = client.GetAsync(client.BaseAddress.ToString() + id).Result;
            if (responseMessage.IsSuccessStatusCode)
            {
                var responseData = responseMessage.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<U>(responseData);
            }
            return default(U);
        }

        public void Delete(int id)
        {
            client.DeleteAsync(client.BaseAddress.ToString() + id).Wait();
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
    }
}