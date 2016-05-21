using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TDiary.Model;

namespace TDiary 
{
    public class EFTestController : Controller
    {
        private readonly ILogger<EFTestController> _logger;
        private readonly TestContext _context;
        
        public EFTestController(ILogger<EFTestController> logger, TestContext context)
        {
            _context = context;
            _logger = logger;
        }
        
        public IActionResult Add()
        {
            _logger.LogInformation("User Requested to Add an EF test object");
            return View();
        }
        
        [HttpPost]
        public IActionResult Add(EFTest vm)
        {
            _context.Tests.Add(new EFTest { SomeText = vm.SomeText });
            _context.SaveChanges();

            _logger.LogInformation("User Added an EF test object");
            
            return RedirectToAction("Index", "Home");
        }
    }
}