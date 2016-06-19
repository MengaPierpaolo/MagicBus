using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
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
        IEnumerable<RecentExperienceViewModel> GetRecent();
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
        }

        public void SetUrl(string url)
        {
            client.BaseAddress = new Uri(baseUrl + url);
        }

        public IEnumerable<RecentExperienceViewModel> GetRecent()
        {
            // TODO: asynch / await this?
            HttpResponseMessage responseMessage = client.GetAsync(client.BaseAddress).Result;
            if (responseMessage.IsSuccessStatusCode)
            {
                var responseData = responseMessage.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<List<RecentExperienceViewModel>>(responseData);
            }

            return null; // TODO: Look at what this should be
        }

        public void Add(DiaryItem item)
        {
            HttpContent contentPost = new StringContent(JsonConvert.SerializeObject(item), Encoding.UTF8, "application/json");
            client.PostAsync(client.BaseAddress, contentPost);
        }

        public void Delete(int id)
        {
            client.DeleteAsync(client.BaseAddress.ToString() + id);
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

        public void SaveChanges(DiaryItem item)
        {
            HttpContent contentPost = new StringContent(JsonConvert.SerializeObject(item), Encoding.UTF8, "application/json");
            client.PutAsync(client.BaseAddress.ToString() + item.Id, contentPost);
        }
    }
}