using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TDiary.ViewModel;
using TDiary.Repository;
using TDiary.Model;

namespace TDiary
{
    public class HomeController : Controller
    {
        private readonly DiaryItemListRepository _repository;
        private readonly ILogger<HomeController> _logger;
        
        public HomeController(DiaryItemListRepository repository, ILogger<HomeController> logger)
        {
            _repository = repository;
            _logger = logger;
        }
        
        public IActionResult Index() 
        {
            var data = _repository.GetRecentExperiences(PageSize.Ten);
            var returnData = new List<ActivityViewModel>();
           
            returnData.AddRange(data.Where(i => i is Chow).Cast<Chow>().Select(c => new ChowViewModel { Id = c.Id, Date = c.Date, Description = c.Description, Experience = c.Experience }));
            returnData.AddRange(data.Where(i => i is Trip).Cast<Trip>().Select(t => new TripViewModel { Id = t.Id, Date = t.Date, From = t.From, To = t.To, Experience = t.Experience }));
            returnData.AddRange(data.Where(i => i is Sight).Cast<Sight>().Select(s => new SightViewModel { Id = s.Id, Date = s.Date, Name = s.Name, Experience = s.Experience }));

            var vm = new HomeViewModel()
            {
                Title = "Magic Bus",
                Heading = "Your groovy new travel diary!",
                Activities = returnData.OrderByDescending(a => a.Date)
            };
            
            return View(vm);    
        }
    }
}