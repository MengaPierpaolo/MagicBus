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
            _logger.LogInformation("User is adding a Sight");

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
                    _logger.LogInformation("User added a Sight");

                    return RedirectToAction("Index", "Home");
                }

                return View(vm);
            }

            return RedirectToAction("Index", "Home");
        }
        
        
        public IActionResult Edit(int id)
        {
            _logger.LogInformation("User is editing a Sight");

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
                    _context.Attach(Sight.Create(vm.Id, vm.Date, vm.Name, vm.Location))
                        .State = EntityState.Modified;

                    _context.SaveChanges();
                    _logger.LogInformation("User edited a Sight");

                    return RedirectToAction("Index", "Home");
                }
                return View(vm);
            }

            return RedirectToAction("Index", "Home");
        }
        
        public IActionResult Delete(int id)
        {
            _context.Entry(Sight.Create(id)).State = EntityState.Deleted;
            _context.SaveChanges();
            _logger.LogInformation("User deleted a Sight");

            return RedirectToAction("Index", "Home");
        }
    }
}