using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TDiary.Model;
using TDiary.Repository;
using TDiary.ViewModel;

namespace TDiary
{
    public class SightController : DiaryController<Sight>
    {
        private readonly ILogger<SightController> _logger;

        public SightController(
            IDiaryItemRepository repository, 
            ILocationProvider locationProvider, 
            ILogger<SightController> logger) : base(repository, locationProvider)
        {
            _logger = logger;
        }

        public IActionResult Add()
        {
            _logger.LogInformation("User is adding a Sight");
            return View(new SightViewModel() { Location = _locationProvider.GetLastLocation()});
        }

        [HttpPost]
        public IActionResult Add(SightViewModel vm)
        {
            if (vm.SubmitButtonUsed == "Save it!")
            {
                if (!ModelState.IsValid)
                {
                    return View(vm);
                }

                _repository.Add(new Sight(vm.Date, vm.Name) { Location = vm.Location });
                _logger.LogInformation("User added a Sight");
            }

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Edit(int id)
        {
            _logger.LogInformation("User is editing a Sight");

            var d = _repository.Get<Sight>(id);
            var vm = new SightViewModel { Id = d.Id, Location = d.Location, Name = d.Name };

            return View(vm);
        }

        [HttpPost]
        public IActionResult Edit(SightViewModel vm)
        {
            if (vm.SubmitButtonUsed == "Save it!")
            {
                if (!ModelState.IsValid)
                {
                    return View(vm);
                }

                _repository.SaveChanges(Sight.Create(vm.Id, vm.Date, vm.Name, vm.Location));
                _logger.LogInformation("User edited a Sight");
            }

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Delete(int id)
        {
            _repository.Delete(Sight.Create(id));
            _logger.LogInformation("User deleted a Sight");

            return RedirectToAction("Index", "Home");
        }
    }
}