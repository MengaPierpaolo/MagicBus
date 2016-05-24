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
        private readonly TestContext _context;
        
        public HomeController(ILogger<HomeController> logger, TestContext context)
        {
            _logger = logger;
            _context = context;
        }
        
        public IActionResult Index() 
        {
            _logger.LogInformation("Index Called. And I Wanted to log the fact here!");

            var data = _context.Tests.ToList() ?? new List<Model.EFTest>();

            var vm = new HomeViewModel("Funky App")
            {
                Heading = "Hello There Groovy ASP.NET Core MVC!",
                Message = string.Format("Last Added Item: {0}", data.Count==0 ? "Fresh Database!": data.LastOrDefault().SomeText),
                EFTests = data
            };
            
            return View(vm);    
        }
    }
}