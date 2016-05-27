using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TDiary.Model;

namespace TDiary
{
    public class SightController : DiaryController
    {
        private readonly ILogger<SightController> _logger;
        
        public SightController(DiaryContext context, ILogger<SightController> logger) : base(context)
        {
            _logger = logger;
        }
        
        public IActionResult Add()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Add(Sight vm)
        {
            var visitDate = DateTime.Now;
            
            _context.Sights.Add(new Sight(visitDate) { Name = vm.Name });
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}