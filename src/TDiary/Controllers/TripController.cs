using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TDiary.Model;
using TDiary.Providers.ViewModel.Model;

namespace TDiary
{
    public class TripController : DiaryController<Trip, TripViewModel>
    {
        public TripController(ApiProxy<Trip, TripViewModel> apiProxy) : base(apiProxy) { }

        [HttpPost]
        public async Task<IActionResult> Add(TripViewModel vm)
        {
            if (vm.SavePressed)
            {
                if (!ModelState.IsValid)
                    return View(_apiProxy.RefreshAddViewModel(vm));

                await _apiProxy.Add(new Trip(vm.Date, vm.From, vm.To, vm.By));
            }

            return RedirectToAction("Index", "Home");
        }


        [HttpPost]
        public async Task<IActionResult> Edit(TripViewModel vm)
        {
            if (vm.SavePressed)
            {
                if (!ModelState.IsValid)
                    return View(_apiProxy.RefreshEditViewModel(vm));

                await _apiProxy.SaveChanges(Trip.Create(vm.Id, vm.Date, vm.From, vm.To, vm.By, vm.SavePosition));
            }

            return RedirectToAction("Index", "Home");
        }
    }
}