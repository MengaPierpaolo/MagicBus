using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TDiary.Model;
using TDiary.Repository;
using TDiary.ViewModel;

namespace TDiary
{
    public class TripController : DiaryController<Trip>
    {
        private readonly ILogger<TripController> _logger;

        public TripController(IDiaryItemRepository repository, ILogger<TripController> logger) : base(repository)
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
                if (!ModelState.IsValid)
                {
                    return View(vm);
                }

                _repository.Add(new Trip(vm.Date, vm.From, vm.To, vm.ModeOfTransport));
                _logger.LogInformation("User added a Trip");
            }

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Edit(int id)
        {
            _logger.LogInformation("User is editing a Trip");

            var d = _repository.Get<Trip>(id);
            var vm = new TripViewModel { Id = d.Id, From = d.From, To = d.To, ModeOfTransport = d.By };

            return View(vm);
        }

        [HttpPost]
        public IActionResult Edit(TripViewModel vm)
        {
            if (vm.SubmitButtonUsed == "Save it!")
            {
                if (!ModelState.IsValid)
                {
                    return View(vm);
                }
                
                _repository.SaveChanges(Trip.Create(vm.Id, vm.Date, vm.From, vm.To, vm.ModeOfTransport));
                _logger.LogInformation("User edited a Trip");
            }

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Delete(int id)
        {
            _repository.Delete(Trip.Create(id));
            _logger.LogInformation("User deleted a Trip");

            return RedirectToAction("Index", "Home");
        }
    }
}