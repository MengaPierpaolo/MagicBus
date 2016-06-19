using Microsoft.AspNetCore.Mvc;
using TDiary.Model;
using TDiary.Providers.ViewModel.Model;

namespace TDiary
{
    public class NapController : DiaryController<Nap, NapViewModel>
    {
        public NapController(ApiProxy<Nap, NapViewModel> apiProxy) : base(apiProxy) { }

        [HttpPost]
        public IActionResult Add(NapViewModel vm)
        {
            if (vm.SavePressed)
            {
                if (!ModelState.IsValid)
                    return View(_apiProxy.RefreshAddViewModel(vm));

                _apiProxy.Add(new Nap(vm.Date, vm.Description) { Location = vm.Location });
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult Edit(NapViewModel vm)
        {
            if (vm.SavePressed)
            {
                if (!ModelState.IsValid)
                    return View(_apiProxy.RefreshEditViewModel(vm));

                _apiProxy.SaveChanges(Nap.Create(vm.Id, vm.Date, vm.Description, vm.Location, vm.SavePosition));
            }

            return RedirectToAction("Index", "Home");
        }
    }
}