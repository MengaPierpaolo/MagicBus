using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TDiary.ViewModels;
using System.Collections.Generic;
using TDiary.Model;

namespace TDiary
{
    public class HomeController : DiaryController
    {
        private readonly ILogger<HomeController> _logger;
        
        public HomeController(DiaryContext context, ILogger<HomeController> logger) : base(context)
        {
            _logger = logger;
        }
        
        public IActionResult Index() 
        {
            _logger.LogInformation("Index Called. And I Wanted to log the fact here!");

            List<DiaryItem> data = _context.Chows.Cast<DiaryItem>().ToList();
            data.AddRange(_context.Trips.Cast<DiaryItem>().ToList());
            data.AddRange(_context.Sights.Cast<DiaryItem>().ToList());

            var vm = new HomeViewModel("Magic Bus")
            {
                Heading = "Your groovy new travel diary!",
                Experiences = data
            };
            
            return View(vm);    
        }
    }
}