using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            if (vm.SubmitButtonUsed == "Save it!")
            {
                if (ModelState.IsValid)
                {
                    _context.Experiences.Add(new Chow(vm.Date, vm.Description));
                    _context.SaveChanges();

                    _logger.LogInformation("User added some Chow");
                    return RedirectToAction("Index", "Home");
                }

                return View(vm);
            }
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Edit(int id)
        {
            var vm = _context.Experiences.OfType<Chow>()
                .Where(e => e.Id == id)
                .Select(c => new ChowViewModel { Id = c.Id, Date = c.Date, Description = c.Description, Experience = c.Experience })
                .First();

            return View(vm);
        }

        [HttpPost]
        public IActionResult Edit(ChowViewModel vm)
        {
            if (vm.SubmitButtonUsed == "Save it!")
            {
                if (ModelState.IsValid)
                {
                    _context.Experiences
                        .Attach(new Chow(vm.Date, vm.Description) { Id = vm.Id })
                        .State = EntityState.Modified;
            
                    _context.SaveChanges();

                   return RedirectToAction("Index", "Home");
                }
                
                return View(vm);
            }
            
            return RedirectToAction("Index", "Home");
        }
        
        public IActionResult Delete(int id)
        {
            var item = new Chow(DateTime.UtcNow, string.Empty ) { Id = id };
            _context.Entry(item).State = EntityState.Deleted;
            _context.SaveChanges();
            
            return RedirectToAction("Index", "Home");
        }

    }
}