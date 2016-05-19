using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace TDiary
{
    public class HomeController : Controller
    {
        ILogger<HomeController> _logger;
        
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        
        public IActionResult Index() 
        {
            _logger.LogWarning("Index Called. And I Wanted to log the fact here!");
            
            var vm = new HomeViewModel()
            {
                Title = "ASP.Net Core - TDiary",
                Heading = "Funky App!",
                Message = "Hello There Groovy ASP.NET Core MVC!"
            };

            return View(vm);    
        }
    }
    
    public class HomeViewModel
    {
        public string Title { get; internal set; }
        public string Heading { get; set; }
        public string Message { get; internal set; }
    }
}