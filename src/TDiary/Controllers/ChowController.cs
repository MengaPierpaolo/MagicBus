using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TDiary.Model;
using TDiary.ViewModel;

namespace TDiary
{
    public class ChowController : DiaryController
    {
        private readonly ILogger<ChowController> _logger;
        
        public ChowController(DiaryContext context, ILogger<ChowController> logger) : base(context) 
        {
            _logger = logger;
        }
        
        public IActionResult Add() 
        {
            return View(new ChowViewModel());
        }
        
        [HttpPost]
        public IActionResult Add(ChowViewModel vm)
        {
            if (vm.SubmitButtonUsed == "Add it!")
            {
                var chowDate = DateTime.Now;
                
                _context.Chows.Add(new Chow(chowDate) { Description = vm.Description });
                _context.SaveChanges();
                
                _logger.LogInformation("User added some Chow");
            }            
            return RedirectToAction("Index", "Home");
        }
    }
}