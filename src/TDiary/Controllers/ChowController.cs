using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TDiary.Model;
using TDiary.Repository;
using TDiary.ViewModel;

namespace TDiary
{
    public class ChowController : DiaryController<Chow>
    {
        private readonly ILogger<ChowController> _logger;

        public ChowController(
            IDiaryItemRepository repository, 
            ILocationProvider locationProvider, 
            ILogger<ChowController> logger) : base(repository, locationProvider)
        {
            _logger = logger;
        }

        public IActionResult Add()
        {
            _logger.LogInformation("User is adding some Chow");
            return View(new ChowViewModel() {Location = _locationProvider.GetLastLocation()});
        }

        [HttpPost]
        public IActionResult Add(ChowViewModel vm)
        {
            if (vm.SubmitButtonUsed == "Save it!")
            {
                if (!ModelState.IsValid)
                {
                    return View(vm);
                }
                
                _repository.Add(new Chow(vm.Date, vm.Description) { Location = vm.Location });
                _logger.LogInformation("User added some Chow");
            }

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Edit(int id)
        {
            _logger.LogInformation("User is editing some Chow");

            var c = _repository.Get<Chow>(id);
            var vm = new ChowViewModel { Id = c.Id, Date = c.Date, Location = c.Location, Description = c.Description, Experience = c.Experience };

            return View(vm);
        }

        [HttpPost]
        public IActionResult Edit(ChowViewModel vm)
        {
            if (vm.SubmitButtonUsed == "Save it!")
            {
                if (!ModelState.IsValid)
                {
                    return View(vm);
                }

                _repository.SaveChanges(Chow.Create(vm.Id, vm.Date, vm.Description, vm.Location));
                _logger.LogInformation("User edited some Chow");
            }

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Delete(int id)
        {
            _repository.Delete(Chow.Create(id));
            _logger.LogInformation("User deleted some Chow");

            return RedirectToAction("Index", "Home");
        }
    }
}