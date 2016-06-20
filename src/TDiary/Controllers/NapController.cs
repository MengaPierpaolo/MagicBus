using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TDiary.Model;
using TDiary.Providers.ViewModel.Model;

namespace TDiary
{
    public class NapController : DiaryController<Nap, NapViewModel>
    {
        public NapController(ApiProxy<Nap, NapViewModel> apiProxy) : base(apiProxy) { }

        [HttpPost]
        public async Task<IActionResult> Add(NapViewModel vm)
        {
            if (vm.SavePressed)
            {
                if (!ModelState.IsValid)
                    return View(_apiProxy.RefreshAddViewModel(vm));

                await _apiProxy.Add(new Nap(vm.Date, vm.Description) { Location = vm.Location });
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(NapViewModel vm)
        {
            if (vm.SavePressed)
            {
                if (!ModelState.IsValid)
                    return View(_apiProxy.RefreshEditViewModel(vm));

                await _apiProxy.SaveChanges(Nap.Create(vm.Id, vm.Date, vm.Description, vm.Location, vm.SavePosition));
            }

            return RedirectToAction("Index", "Home");
        }
    }
}