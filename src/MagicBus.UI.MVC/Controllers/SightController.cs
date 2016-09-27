using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MagicBus.Model;
using MagicBus.Providers.ViewModel;
using MagicBus.Providers.ViewModel.Model;

namespace MagicBus
{
    public class SightController : DiaryController<Sight, SightViewModel>
    {
        private readonly IViewModelProvider<Sight, SightViewModel> _viewModelProvider;

        public SightController(
            IApiProxy apiProxy,
            IViewModelProvider<Sight, SightViewModel> viewModelProvider) : base(apiProxy)
        {
            _viewModelProvider = viewModelProvider;
        }

        [HttpPost]
        public async Task<IActionResult> Add(SightViewModel vm)
        {
            if (vm.SavePressed)
            {
                if (!ModelState.IsValid)
                    return View(await _viewModelProvider.RefreshAddViewModel(vm));

                await _apiProxy.Add(new Sight(vm.Date, vm.Name) { Location = vm.Location, Rating = vm.Rating, Journey = vm.Journey });
            }

            if (vm.LocationPressed)
            {
                ModelState.ClearValidationState("Name");
                return View(await _viewModelProvider.RefreshAddViewModel(vm));
            }

            return RedirectToAction(nameof(HomeController.Index), GetRedirectController(nameof(HomeController)));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SightViewModel vm, string sourceLocation)
        {
            if (vm.SavePressed)
            {
                if (!ModelState.IsValid)
                    return View(_viewModelProvider.RefreshEditViewModel(vm));

                await _apiProxy.Save(Sight.Create(vm.Id, vm.Date, vm.Name, vm.Location, vm.SavePosition, vm.Rating, vm.Journey));
            }

            if (vm.DeletePressed)
            {
                await _apiProxy.Delete<Sight>(vm.Id);
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

            var vm = await _apiProxy.Get<SightViewModel>(id);
            return View(_viewModelProvider.RefreshEditViewModel(vm));
        }

        public async Task<IActionResult> Delete(int id, string sourceLocation)
        {
            await _apiProxy.Delete<Sight>(id);
            return RedirectToAction(nameof(HomeController.Index), GetRedirectController(nameof(HomeController), sourceLocation));
        }
    }
}