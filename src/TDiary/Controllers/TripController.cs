using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TDiary.Model;
using TDiary.ViewModel;

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
            _logger.LogInformation("User is adding a Trip");
            return View(new TripViewModel());
        }

        [HttpPost]
        public IActionResult Add(TripViewModel vm)
        {
            if (vm.SubmitButtonUsed == "Save it!")
            {
                if (ModelState.IsValid)
                {
                    _context.Experiences.Add(new Trip(vm.Date, vm.From, vm.To, vm.ModeOfTransport));
                    _context.SaveChanges();

                    _logger.LogInformation("User added a Trip");
                    return RedirectToAction("Index", "Home");
                }

                return View(vm);
            }
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Edit(int id)
        {
            _logger.LogInformation("User is editing a Trip");
            var vm = _context.Experiences.OfType<Trip>()
                .Where(d => d.Id == id)
                .Select(d => new TripViewModel() { Id = d.Id, From = d.From, To = d.To, ModeOfTransport = d.By })
                .First();

            return View(vm);
        }

        [HttpPost]
        public IActionResult Edit(TripViewModel vm)
        {
            if (vm.SubmitButtonUsed == "Save it!")
            {
                if (ModelState.IsValid)
                {
                    _context.Attach(Trip.Create(vm.Id, vm.Date, vm.From, vm.To, vm.ModeOfTransport))
                        .State = EntityState.Modified;

                    _context.SaveChanges();
                    _logger.LogInformation("User edited a Trip");

                    return RedirectToAction("Index", "Home");
                }
                return View(vm);
            }

            return RedirectToAction("Index", "Home");
        }
        
        public IActionResult Delete(int id)
        {
            _context.Entry(Trip.Create(id)).State = EntityState.Deleted;
            _context.SaveChanges();
            _logger.LogInformation("User deleted a Trip");

            return RedirectToAction("Index", "Home");
        }
    }
}