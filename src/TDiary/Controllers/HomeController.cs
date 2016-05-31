using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TDiary.ViewModel;
using TDiary.Model;

namespace TDiary
{
    public class HomeController : DiaryController
    {
        private readonly ILogger<HomeController> _logger;
        
        public HomeController(DiaryContext context, ILogger<HomeController> logger) : base(context)
        {
            _logger = logger;
        }
        
        public IActionResult Index() 
        {
            List<Activity> data = new List<Activity>();
            data.AddRange(_context.Experiences.OfType<Chow>().Select(c => new ChowViewModel { Date = c.Date, Description = c.Description, Experience = c.Experience }));
            data.AddRange(_context.Experiences.OfType<Trip>().Select(t => new TripViewModel { Date = t.Date, From = t.From, To = t.To, Experience = t.Experience }));
            data.AddRange(_context.Experiences.OfType<Sight>().Select(s => new SightViewModel { Date = s.Date, Name = s.Name, Experience = s.Experience }));

            var vm = new HomeViewModel("Magic Bus")
            {
                Heading = "Your groovy new travel diary!",
                Activities = data.OrderByDescending(e => e.Date)
            };
            
            return View(vm);    
        }
    }
}