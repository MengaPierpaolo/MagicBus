using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TDiary.Model;

namespace TDiary 
{
    public class TripController : Controller
    {
        private readonly ILogger<TripController> _logger;
        private readonly DiaryContext _context;
        
        public TripController(ILogger<TripController> logger, DiaryContext context)
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
        public IActionResult Add(Trip vm)
        {
            _context.Trips.Add(new Trip { Snippet = vm.Snippet });
            _context.SaveChanges();

            _logger.LogInformation("User Added a Trip");
            
            return RedirectToAction("Index", "Home");
        }
    }
}