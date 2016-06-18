using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TDiary.Providers.ViewModel.Model;
using TDiary.Repository;
using TDiary.Service;
using System.Net.Http;
using System;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.Extensions.Options;

namespace TDiary
{
    public class HomeController : Controller
    {
        private readonly DiaryItemListRepository _repository;
        private readonly IActivityOrderService _activityOrderer;

        private HttpClient client;
        private string _url;

        public HomeController(IOptions<DatabaseSettings> options, DiaryItemListRepository repository, IActivityOrderService activityOrderer)
        {
            _repository = repository;
            _activityOrderer = activityOrderer;

            _url = options.Value.BaseApiUrl + "/diaryitems";
            client = new HttpClient();
            client.BaseAddress = new Uri(_url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<IActionResult> Index()
        {
            HttpResponseMessage responseMessage = await client.GetAsync(_url);

            if (responseMessage.IsSuccessStatusCode)
            {
                var responseData = responseMessage.Content.ReadAsStringAsync().Result;

                var data = JsonConvert.DeserializeObject<List<RecentExperienceViewModel>>(responseData);

                var vm = new HomeViewModel()
                {
                    Title = "Magic Bus",
                    Heading = "Your groovy new travel diary!",
                    RecentExperiences = data.OrderByDescending(d => d.Date)
                        .ThenByDescending(pos => pos.SavePosition)
                };

                return View(vm);
            }

            return View("Error");
        }

        public IActionResult OrderActivityUp(int activityId)
        {
            _activityOrderer.OrderUp(activityId);
            return RedirectToAction("Index");
        }

        public IActionResult OrderActivityDown(int activityId)
        {
            _activityOrderer.OrdrDown(activityId);
            return RedirectToAction("Index");
        }
    }
}