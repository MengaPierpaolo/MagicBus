using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TDiary.Model;
using TDiary.ViewModel;

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
            return View(new SightViewModel());
        }

        [HttpPost]
        public IActionResult Add(SightViewModel vm)
        {
            if (vm.SubmitButtonUsed == "Save it!")
            {
                if (ModelState.IsValid)
                {
                    _context.Experiences.Add(new Sight(vm.Date, vm.Name) { Location = vm.Location });
                    _context.SaveChanges();

                    return RedirectToAction("Index", "Home");
                }

                return View(vm);
            }

            return RedirectToAction("Index", "Home");
        }
        
        
        public IActionResult Edit(int id)
        {
            var vm = _context.Experiences.OfType<Sight>()
                .Where(d => d.Id == id)
                .Select(d => new SightViewModel() { Id = d.Id, Location = d.Location, Name = d.Name })
                .First();

            return View(vm);
        }

        [HttpPost]
        public IActionResult Edit(SightViewModel vm)
        {
            if (vm.SubmitButtonUsed == "Save it!")
            {
                if (ModelState.IsValid)
                {
                    _context.Attach(new Sight(vm.Date, vm.Name) { Id = vm.Id, Location = vm.Location })
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
            var item = new Sight(DateTime.UtcNow, string.Empty ) { Id = id };
            _context.Entry(item).State = EntityState.Deleted;
            _context.SaveChanges();
            
            return RedirectToAction("Index", "Home");
        }
    }
}