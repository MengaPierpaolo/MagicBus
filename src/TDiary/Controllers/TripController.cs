using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
            _logger.LogInformation("User started to add a Trip");

            var vm = new TripViewModel
            {
                Transport = new List<SelectListItem> {
                new SelectListItem { Value = "1", Text = "Bus" },
                new SelectListItem { Value = "2", Text = "Train" },
                new SelectListItem { Value = "3", Text = "Plane" }
            }
            };

            return View(vm);
        }

        [HttpPost]
        public IActionResult Add(TripViewModel vm)
        {
            if (vm.SubmitButtonUsed == "Add it!")
            {
                if (ModelState.IsValid)
                {
                    _context.Experiences.Add(new Trip(vm.Date, vm.From, vm.To, vm.ModeOfTransport));
                    _context.SaveChanges();

                    _logger.LogInformation("User added a Trip");
                    return RedirectToAction("Index", "Home");
                }
             
                // TODO: Rebuild vm
                return View(vm);
            }
            return RedirectToAction("Index", "Home");
        }
    }
}