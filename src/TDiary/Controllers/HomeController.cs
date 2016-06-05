using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TDiary.ViewModel;
using TDiary.Repository;
using TDiary.Model;

namespace TDiary
{    
    public class HomeController : Controller
    {
        private readonly DiaryItemListRepository _repository;
        private readonly IActivityOrderService _activityOrderer;
        
        public HomeController(DiaryItemListRepository repository, IActivityOrderService activityOrderer)
        {
            _repository = repository;
            _activityOrderer = activityOrderer;
        }
        
        public IActionResult Index() 
        {
            var data = _repository.GetRecentExperiences(PageSize.Ten);
            var returnData = new List<ActivityViewModel>();
           
            returnData.AddRange(
                data.Where(i => i is Chow).Cast<Chow>()
                .Select(c => new ChowViewModel { Id = c.Id, Date = c.Date, Description = c.Description, Experience = c.Experience, SavePosition = c.SavePosition }));

            returnData.AddRange(
                data.Where(i => i is Trip).Cast<Trip>()
                .Select(t => new TripViewModel { Id = t.Id, Date = t.Date, From = t.From, To = t.To, Experience = t.Experience, SavePosition = t.SavePosition }));

            returnData.AddRange(
                data.Where(i => i is Sight).Cast<Sight>()
                .Select(s => new SightViewModel { Id = s.Id, Date = s.Date, Name = s.Name, Experience = s.Experience, SavePosition = s.SavePosition }));

            var vm = new HomeViewModel()
            {
                Title = "Magic Bus",
                Heading = "Your groovy new travel diary!",
                Activities = returnData.OrderByDescending(d => d.Date)
                    .ThenByDescending(pos => pos.SavePosition)
            };
            
            return View(vm);    
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