using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MagicBus.Model;
using MagicBus.Providers.ViewModel;
using MagicBus.Providers.ViewModel.Model;

namespace MagicBus
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
                    return View(await _viewModelProvider.RefreshAddViewModel(vm));

                await _apiProxy.Add(new Nap(vm.Date, vm.Description) { Location = vm.Location, Rating = vm.Rating, Journey = vm.Journey });
            }

            if (vm.LocationPressed || vm.DatePressed)
            {
                ModelState.ClearValidationState("Description");
                return View(await _viewModelProvider.RefreshAddViewModel(vm));
            }

            return RedirectToAction(nameof(HomeController.Index), GetRedirectController(nameof(HomeController)));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(NapViewModel vm, string sourceLocation)
        {
            if (vm.SavePressed)
            {
                if (!ModelState.IsValid)
                    return View(_viewModelProvider.RefreshEditViewModel(vm));

                await _apiProxy.Save(Nap.Create(vm.Id, vm.Date, vm.Description, vm.Location, vm.SavePosition, vm.Rating, vm.Journey));
            }

            if (vm.DeletePressed)
            {
                await _apiProxy.Delete<Nap>(vm.Id);
            }

            return RedirectToAction(nameof(HomeController.Index), GetRedirectController(nameof(HomeController), sourceLocation));
        }

        public async Task<IActionResult> Add()
        {
            return View(await _viewModelProvider.CreateAddViewModel());
        }

        public async Task<IActionResult> Edit(int id, string sourceLocation)
        {
            ViewData["sourceLocation"] = sourceLocation;

            var vm = await _apiProxy.Get<NapViewModel>(id);
            return View(_viewModelProvider.RefreshEditViewModel(vm));
        }

        public async Task<IActionResult> Delete(int id, string sourceLocation)
        {
            await _apiProxy.Delete<Nap>(id);
            return RedirectToAction(nameof(HomeController.Index), GetRedirectController(nameof(HomeController), sourceLocation));
        }
    }
}