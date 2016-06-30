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
        public async Task<IActionResult> Add(TripViewModel vm)
        {
            if (vm.SavePressed)
            {
                if (!ModelState.IsValid)
                    return View(_viewModelProvider.RefreshAddViewModel(vm));

                await _apiProxy.Add(new Trip(vm.Date, vm.From, vm.To, vm.By) { Rating = vm.Rating });
            }

            return RedirectToAction("Index", "Home");
        }


        [HttpPost]
        public async Task<IActionResult> Edit(TripViewModel vm)
        {
            if (vm.SavePressed)
            {
                if (!ModelState.IsValid)
                    return View(_viewModelProvider.RefreshEditViewModel(vm));

                await _apiProxy.Save(Trip.Create(vm.Id, vm.Date, vm.From, vm.To, vm.By, vm.SavePosition, vm.Rating));
            }

            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Add()
        {
            return View(await _viewModelProvider.CreateAddViewModel());
        }

        public async Task<IActionResult> Edit(int id)
        {
            var vm = await _apiProxy.Get<TripViewModel>(id);
            return View(_viewModelProvider.RefreshEditViewModel(vm));
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _apiProxy.Delete<Trip>(id);
            return RedirectToAction("Index", "Home");
        }
    }
}