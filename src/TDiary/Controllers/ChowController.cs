using Microsoft.AspNetCore.Mvc;
using TDiary.Model;
using TDiary.Repository;
using TDiary.ViewModel;

namespace TDiary
{
    public class ChowController : DiaryController<Chow>
    {
        private readonly IViewModelProvider<Chow, ChowViewModel> _viewModelProvider;

        public ChowController(
            IDiaryItemRepository repository,
            IViewModelProvider<Chow, ChowViewModel> viewModelProvider) : base(repository)
        {
            _viewModelProvider = viewModelProvider;
        }

        public IActionResult Add()
        {
            return View(_viewModelProvider.CreateAddViewModel());
        }

        [HttpPost]
        public IActionResult Add(ChowViewModel vm)
        {
            if (vm.SavePressed)
            {
                if (!ModelState.IsValid) 
                    return View(vm);

                _repository.Add(new Chow(vm.Date, vm.Description) { Location = vm.Location });
            }

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Edit(int id)
        {
            return View(_viewModelProvider.CreateEditViewModel(_repository.Get<Chow>(id)));
        }

        [HttpPost]
        public IActionResult Edit(ChowViewModel vm)
        {
            if (vm.SavePressed)
            {
                if (!ModelState.IsValid)
                    return View(vm);

                _repository.SaveChanges(Chow.Create(vm.Id, vm.Date, vm.Description, vm.Location, vm.SavePosition));
            }

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Delete(int id)
        {
            _repository.Delete(Chow.Create(id));
            return RedirectToAction("Index", "Home");
        }
    }
}