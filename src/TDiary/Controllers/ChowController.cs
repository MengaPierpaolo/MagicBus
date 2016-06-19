using Microsoft.AspNetCore.Mvc;
using TDiary.Model;
using TDiary.Providers.ViewModel.Model;

namespace TDiary
{
    public class ChowController : DiaryController<Chow, ChowViewModel>
    {
        public ChowController(ApiProxy<Chow, ChowViewModel> apiProxy) : base(apiProxy) { }

        [HttpPost]
        public IActionResult Add(ChowViewModel vm)
        {
            if (vm.SavePressed)
            {
                if (!ModelState.IsValid)
                    return View(_apiProxy.RefreshAddViewModel(vm));

                _apiProxy.Add(new Chow(vm.Date, vm.Description) { Location = vm.Location });
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult Edit(ChowViewModel vm)
        {
            if (vm.SavePressed)
            {
                if (!ModelState.IsValid)
                    return View(_apiProxy.RefreshEditViewModel(vm));

                _apiProxy.SaveChanges(Chow.Create(vm.Id, vm.Date, vm.Description, vm.Location, vm.SavePosition));
            }

            return RedirectToAction("Index", "Home");
        }
    }
}