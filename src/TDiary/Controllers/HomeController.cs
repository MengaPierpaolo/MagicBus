using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TDiary.ViewModels;
using System.Collections.Generic;

namespace TDiary
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DiaryContext _context;
        
        public HomeController(ILogger<HomeController> logger, DiaryContext context)
        {
            _logger = logger;
            _context = context;
        }
        
        public IActionResult Index() 
        {
            _logger.LogInformation("Index Called. And I Wanted to log the fact here!");

            var data = _context.Trips.ToList() ?? new List<Model.Trip>();

            var vm = new HomeViewModel("Magic Bus")
            {
                Heading = "Your groovy new travel diary!",
                Message = string.Format("Last Added Item: {0}", data.Count==0 ? "New Account!": data.LastOrDefault().Snippet),
                Trips = data
            };
            
            return View(vm);    
        }
    }
}