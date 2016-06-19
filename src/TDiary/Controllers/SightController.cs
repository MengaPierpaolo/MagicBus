using Microsoft.AspNetCore.Mvc;
using TDiary.Model;
using TDiary.Providers.ViewModel.Model;

namespace TDiary
{
    public class SightController : DiaryController<Sight, SightViewModel>
    {
        public SightController(ApiProxy<Sight, SightViewModel> apiProxy) : base(apiProxy) { }

        [HttpPost]
        public IActionResult Add(SightViewModel vm)
        {
            if (vm.SavePressed)
            {
                if (!ModelState.IsValid)
                    return View(_apiProxy.RefreshAddViewModel(vm));

                _apiProxy.Add(new Sight(vm.Date, vm.Name) { Location = vm.Location });
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult Edit(SightViewModel vm)
        {
            if (vm.SavePressed)
            {
                if (!ModelState.IsValid)
                    return View(_apiProxy.RefreshEditViewModel(vm));

                _apiProxy.SaveChanges(Sight.Create(vm.Id, vm.Date, vm.Name, vm.Location, vm.SavePosition));
            }

            return RedirectToAction("Index", "Home");
        }
    }
}