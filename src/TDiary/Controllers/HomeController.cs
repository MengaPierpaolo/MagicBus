using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TDiary.ViewModels;

namespace TDiary
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly TestContext _context;
        
        public HomeController(ILogger<HomeController> logger, TestContext context)
        {
            _logger = logger;
            _context = context;
        }
        
        public IActionResult Index() 
        {
            _logger.LogInformation("Index Called. And I Wanted to log the fact here!");

            var vm = new HomeViewModel("Hello World")
            {
                Heading = "Funky App!",
                Message = "Hello There Groovy ASP.NET Core MVC!",
                EFTests = _context.Tests.ToList()
            };
            
            return View(vm);    
        }
    }
}