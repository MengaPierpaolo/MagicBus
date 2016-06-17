using Microsoft.AspNetCore.Mvc;
using TDiary.Model;
using TDiary.Repository;
using TDiary.Providers.ViewModel;
using TDiary.Providers.ViewModel.Model;


namespace TDiary
{
    public class NapController : DiaryController<Nap>
    {
        private readonly IViewModelProvider<Nap, NapViewModel> _viewModelProvider;

        public NapController(
            IDiaryItemRepository repository,
            IViewModelProvider<Nap, NapViewModel> viewModelProvider) : base(repository)
        {
            _viewModelProvider = viewModelProvider;
        }

        public IActionResult Add()
        {
            return View(_viewModelProvider.CreateAddViewModel());
        }

        [HttpPost]
        public IActionResult Add(NapViewModel vm)
        {
            if (vm.SavePressed)
            {
                if (!ModelState.IsValid)
                    return View(_viewModelProvider.RefreshAddViewModel(vm));

                _repository.Add(new Nap(vm.Date, vm.Description) { Location = vm.Location });
            }

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Edit(int id)
        {
            return View(_viewModelProvider.CreateEditViewModel(_repository.Get<Nap>(id)));
        }

        [HttpPost]
        public IActionResult Edit(NapViewModel vm)
        {
            if (vm.SavePressed)
            {
                if (!ModelState.IsValid)
                    return View(_viewModelProvider.RefreshEditViewModel(vm));

                _repository.SaveChanges(Nap.Create(vm.Id, vm.Date, vm.Description, vm.Location, vm.SavePosition));
            }

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Delete(int id)
        {
            _repository.Delete(Nap.Create(id));
            return RedirectToAction("Index", "Home");
        }
    }
}