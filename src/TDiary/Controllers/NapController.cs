using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TDiary.Model;
using TDiary.Providers.ViewModel;
using TDiary.Providers.ViewModel.Model;

namespace TDiary
{
    public class NapController : DiaryController<Nap, NapViewModel>
    {
        private readonly IViewModelProvider<Nap, NapViewModel> _viewModelProvider;

        public NapController(
            IApiProxy apiProxy,
            IViewModelProvider<Nap, NapViewModel> viewModelProvider) : base(apiProxy)
        {
            _viewModelProvider = viewModelProvider;
        }

        [HttpPost]
        public async Task<IActionResult> Add(NapViewModel vm)
        {
            if (vm.SavePressed)
            {
                if (!ModelState.IsValid)
                    return View(_viewModelProvider.RefreshAddViewModel(vm));

                await _apiProxy.Add(new Nap(vm.Date, vm.Description) { Location = vm.Location, Rating = vm.Rating });
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(NapViewModel vm)
        {
            if (vm.SavePressed)
            {
                if (!ModelState.IsValid)
                    return View(_viewModelProvider.RefreshEditViewModel(vm));

                await _apiProxy.Save(Nap.Create(vm.Id, vm.Date, vm.Description, vm.Location, vm.SavePosition, vm.Rating));
            }

            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Add()
        {
            return View(await _viewModelProvider.CreateAddViewModel());
        }

        public async Task<IActionResult> Edit(int id)
        {
            var vm = await _apiProxy.Get<NapViewModel>(id);
            return View(_viewModelProvider.RefreshEditViewModel(vm));
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _apiProxy.Delete<Nap>(id);
            return RedirectToAction("Index", "Home");
        }
    }
}