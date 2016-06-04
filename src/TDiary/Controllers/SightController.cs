using Microsoft.AspNetCore.Mvc;
using TDiary.Model;
using TDiary.Repository;
using TDiary.ViewModel;

namespace TDiary
{
    public class SightController : DiaryController<Sight>
    {
        private readonly IViewModelProvider<Sight, SightViewModel> _viewModelProvider;

        public SightController(
            IDiaryItemRepository repository,
            IViewModelProvider<Sight, SightViewModel> viewModelProvider) : base(repository)
        {
            _viewModelProvider = viewModelProvider;
        }

        public IActionResult Add()
        {
            return View(_viewModelProvider.CreateAddViewModel());
        }

        [HttpPost]
        public IActionResult Add(SightViewModel vm)
        {
            if (vm.SavePressed)
            {
                if (!ModelState.IsValid) 
                    return View(vm);

                _repository.Add(new Sight(vm.Date, vm.Name) { Location = vm.Location });
            }
            
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Edit(int id)
        {
            return View(_viewModelProvider.CreateEditViewModel(_repository.Get<Sight>(id)));
        }

        [HttpPost]
        public IActionResult Edit(SightViewModel vm)
        {
            if (vm.SavePressed)
            {
                if (!ModelState.IsValid) 
                    return View(vm);

                _repository.SaveChanges(Sight.Create(vm.Id, vm.Date, vm.Name, vm.Location));
            }
            
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Delete(int id)
        {
            _repository.Delete(Sight.Create(id));
            return RedirectToAction("Index", "Home");
        }
    }
}