using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TDiary.ViewModel;
using TDiary.Repository;

namespace TDiary
{
    public class HomeController : Controller
    {
        private readonly DiaryItemRepository _repository;
        private readonly ILogger<HomeController> _logger;
        
        public HomeController(DiaryItemRepository repository, ILogger<HomeController> logger)
        {
            _repository = repository;
            _logger = logger;
        }
        
        public IActionResult Index() 
        {
            List<Activity> data = new List<Activity>();
            
            data.AddRange(_repository.GetChows().Select(c => new ChowViewModel { Id = c.Id, Date = c.Date, Description = c.Description, Experience = c.Experience }));
            data.AddRange(_repository.GetTrips().Select(t => new TripViewModel { Id = t.Id, Date = t.Date, From = t.From, To = t.To, Experience = t.Experience }));
            data.AddRange(_repository.GetSights().Select(s => new SightViewModel { Id = s.Id, Date = s.Date, Name = s.Name, Experience = s.Experience }));

            var vm = new HomeViewModel("Magic Bus")
            {
                Heading = "Your groovy new travel diary!",
                Activities = data.OrderByDescending(e => e.Date).ToList()
            };
            
            return View(vm);    
        }
    }
}