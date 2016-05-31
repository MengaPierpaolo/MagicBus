using Microsoft.AspNetCore.Mvc;
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
            if (vm.SubmitButtonUsed == "Add it!")
            {
                if (ModelState.IsValid)
                {
                    _context.Experiences.Add(new Sight(vm.Date, vm.Name));
                    _context.SaveChanges();

                    return RedirectToAction("Index", "Home");
                }

                // TODO: Rebuild vm
                return View(vm);
            }

            return RedirectToAction("Index", "Home");
        }
    }
}