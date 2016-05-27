using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TDiary.Model;

namespace TDiary 
{
    public class TripController : DiaryController
    {
        private readonly ILogger<TripController> _logger;
        
        public TripController(DiaryContext context, ILogger<TripController> logger) : base(context)
        {
            _logger = logger;
        }
        
        public IActionResult Add()
        {
            _logger.LogInformation("User about to add a Trip");
            return View();
        }
        
        [HttpPost]
        public IActionResult Add(Trip vm)
        {
            var tripDate = DateTime.Now; 
            
            _context.Trips.Add(new Trip(tripDate) { From = vm.From, To = vm.To });
            _context.SaveChanges();

            _logger.LogInformation("User added a Trip");
            
            return RedirectToAction("Index", "Home");
        }
    }
}