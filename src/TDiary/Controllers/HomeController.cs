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

            var vm = new HomeViewModel("Funky App")
            {
                Heading = "Hello There Groovy ASP.NET Core MVC!",
                Message = string.Format("Last Added Item: {0}", _context.Tests.LastOrDefault().SomeText ?? string.Empty),
                EFTests = _context.Tests.ToList()
            };
            
            return View(vm);    
        }
    }
}