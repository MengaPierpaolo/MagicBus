using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TDiary.Model;
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
            _logger.LogWarning("Index Called. And I Wanted to log the fact here!");

            // test EF                      
            var l = _context.Tests.ToList();  
            var title = l.LastOrDefault().SomeText ?? "";
                        
            var vm = new HomeViewModel(title)
            {
                Heading = "Funky App!",
                Message = "Hello There Groovy ASP.NET Core MVC!"
            };
            
            return View(vm);    
        }
        
        public IActionResult AddSomething()
        {
            // allow to run more than once (HACK)
            var l = _context.Tests.ToList();  
            var last = l.LastOrDefault().Id;
            
            // create an entry in ef
            var t = new Test();
            t.Id = last+1;
            t.SomeText = string.Format("Blah Blah {0}", t.Id.ToString());
            
            _context.Add(t);
            _context.SaveChanges();
            
            return RedirectToAction("Index");
        }
    }
}