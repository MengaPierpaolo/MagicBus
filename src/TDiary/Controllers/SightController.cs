using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TDiary.Model;
using TDiary.Providers.ViewModel;
using TDiary.Providers.ViewModel.Model;

namespace TDiary
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
                    return View(_viewModelProvider.RefreshAddViewModel(vm));

                await _apiProxy.Add(new Sight(vm.Date, vm.Name) { Location = vm.Location });
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SightViewModel vm)
        {
            if (vm.SavePressed)
            {
                if (!ModelState.IsValid)
                    return View(_viewModelProvider.RefreshEditViewModel(vm));

                await _apiProxy.Save(Sight.Create(vm.Id, vm.Date, vm.Name, vm.Location, vm.SavePosition));
            }

            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _apiProxy.Delete<Sight>(id);
            return RedirectToAction("Index", "Home");
        }
    }
}