using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MagicBus.Model;
using MagicBus.Providers.ViewModel;
using MagicBus.Providers.ViewModel.Model;

namespace MagicBus
{
    public class ChowController : DiaryController<Chow, ChowViewModel>
    {
        private readonly IViewModelProvider<Chow, ChowViewModel> _viewModelProvider;

        public ChowController(
            IApiProxy apiProxy,
            IViewModelProvider<Chow, ChowViewModel> viewModelProvider) : base(apiProxy)
        {
            _viewModelProvider = viewModelProvider;
        }

        [HttpPost]
        public async Task<IActionResult> Add(ChowViewModel vm)
        {
            if (vm.SavePressed)
            {
                if (!ModelState.IsValid)
                    return View(_viewModelProvider.RefreshAddViewModel(vm));

                await _apiProxy.Add(new Chow(vm.Date, vm.Description) { Location = vm.Location, Rating = vm.Rating, Journey = vm.Journey });
            }

            return RedirectToAction(nameof(HomeController.Index), GetRedirectController(nameof(HomeController)));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ChowViewModel vm, string sourceLocation)
        {
            if (vm.SavePressed)
            {
                if (!ModelState.IsValid)
                    return View(_viewModelProvider.RefreshEditViewModel(vm));

                await _apiProxy.Save(Chow.Create(vm.Id, vm.Date, vm.Description, vm.Location, vm.SavePosition, vm.Rating, vm.Journey));
            }

            if (vm.DeletePressed)
            {
                await _apiProxy.Delete<Chow>(vm.Id);
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

            var vm = await _apiProxy.Get<ChowViewModel>(id);
            return View(_viewModelProvider.RefreshEditViewModel(vm));
        }

        public async Task<IActionResult> Delete(int id, string sourceLocation)
        {
            await _apiProxy.Delete<Chow>(id);
            return RedirectToAction(nameof(HomeController.Index), GetRedirectController(nameof(HomeController), sourceLocation));
        }
    }
}