using Microsoft.AspNetCore.Mvc;
using TDiary.Model;
using TDiary.Providers.ViewModel.Model;

namespace TDiary
{
    public class TripController : DiaryController<Trip, TripViewModel>
    {
        public TripController(ApiProxy<Trip, TripViewModel> apiProxy) : base(apiProxy) { }

        [HttpPost]
        public IActionResult Add(TripViewModel vm)
        {
            if (vm.SavePressed)
            {
                if (!ModelState.IsValid)
                    return View(_apiProxy.RefreshAddViewModel(vm));

                _apiProxy.Add(new Trip(vm.Date, vm.From, vm.To, vm.ModeOfTransport));
            }

            return RedirectToAction("Index", "Home");
        }


        [HttpPost]
        public IActionResult Edit(TripViewModel vm)
        {
            if (vm.SavePressed)
            {
                if (!ModelState.IsValid)
                    return View(_apiProxy.RefreshEditViewModel(vm));

                _apiProxy.SaveChanges(Trip.Create(vm.Id, vm.Date, vm.From, vm.To, vm.ModeOfTransport, vm.SavePosition));
            }

            return RedirectToAction("Index", "Home");
        }
    }
}