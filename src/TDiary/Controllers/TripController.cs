using Microsoft.AspNetCore.Mvc;
using TDiary.Model;
using TDiary.Repository;
using TDiary.ViewModel;

namespace TDiary
{
    public class TripController : DiaryController<Trip>
    {
        private readonly IViewModelProvider<Trip, TripViewModel> _viewModelProvider;

        public TripController(
            IDiaryItemRepository repository,
            IViewModelProvider<Trip, TripViewModel> viewModelProvider) : base(repository)
        {
            _viewModelProvider = viewModelProvider;
        }

        public IActionResult Add()
        {
            return View(_viewModelProvider.CreateAddViewModel());
        }

        [HttpPost]
        public IActionResult Add(TripViewModel vm)
        {
            if (vm.SavePressed)
            {
                if (!ModelState.IsValid) 
                    return View(vm);

                _repository.Add(new Trip(vm.Date, vm.From, vm.To, vm.ModeOfTransport));
            }
            
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Edit(int id)
        {
            return View(_viewModelProvider.CreateEditViewModel(_repository.Get<Trip>(id)));
        }

        [HttpPost]
        public IActionResult Edit(TripViewModel vm)
        {
            if (vm.SavePressed)
            {
                if (!ModelState.IsValid) 
                    return View(vm);

                _repository.SaveChanges(Trip.Create(vm.Id, vm.Date, vm.From, vm.To, vm.ModeOfTransport));
            }
            
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Delete(int id)
        {
            _repository.Delete(Trip.Create(id));
            return RedirectToAction("Index", "Home");
        }
    }
}