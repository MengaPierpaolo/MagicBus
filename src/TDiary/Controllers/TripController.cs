using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TDiary.Model;
using TDiary.Providers.ViewModel;
using TDiary.Providers.ViewModel.Model;

namespace TDiary
{
    // Example: [Authorize(Roles = "Administrator")]
    public class TripController : DiaryController<Trip, TripViewModel>
    {
        private readonly IViewModelProvider<Trip, TripViewModel> _viewModelProvider;

        public TripController(
            IApiProxy apiProxy,
            IViewModelProvider<Trip, TripViewModel> viewModelProvider) : base(apiProxy)
        {
            _viewModelProvider = viewModelProvider;
        }

        [HttpPost]
        public async Task<IActionResult> Add(TripViewModel vm, string sourceLocation)
        {
            if (vm.SavePressed)
            {
                if (!ModelState.IsValid)
                    return View(_viewModelProvider.RefreshAddViewModel(vm));

                await _apiProxy.Add(new Trip(vm.Date, vm.From, vm.To, vm.By) { Rating = vm.Rating, Journey = vm.Journey });
            }

            return RedirectToAction(nameof(HomeController.Index), GetRedirectController(nameof(HomeController)), sourceLocation);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(TripViewModel vm, string sourceLocation)
        {
            if (vm.SavePressed)
            {
                if (!ModelState.IsValid)
                    return View(_viewModelProvider.RefreshEditViewModel(vm));

                await _apiProxy.Save(Trip.Create(vm.Id, vm.Date, vm.From, vm.To, vm.By, vm.SavePosition, vm.Rating, vm.Journey));
            }

            if (vm.DeletePressed)
            {
                await _apiProxy.Delete<Trip>(vm.Id);
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

            var vm = await _apiProxy.Get<TripViewModel>(id);
            return View(_viewModelProvider.RefreshEditViewModel(vm));
        }

        public async Task<IActionResult> Delete(int id, string sourceLocation)
        {
            await _apiProxy.Delete<Trip>(id);
            return RedirectToAction(nameof(HomeController.Index), GetRedirectController(nameof(HomeController), sourceLocation));
        }
    }
}