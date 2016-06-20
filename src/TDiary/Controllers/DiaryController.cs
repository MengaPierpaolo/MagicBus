using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TDiary.Model;
using TDiary.Providers.ViewModel.Model;

namespace TDiary
{
    public abstract class DiaryController<T, U> : Controller where T : DiaryItem where U : ActivityViewModel
    {
        protected readonly ApiProxy<T, U> _apiProxy;

        public DiaryController(ApiProxy<T, U> apiProxy)
        {
            _apiProxy = apiProxy;
        }

        public async Task<IActionResult> Add()
        {
            return View(await _apiProxy.GetAddViewModel());
        }

        public async Task<IActionResult> Edit(int id)
        {
            return View(await _apiProxy.GetEditViewModel(id));
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _apiProxy.Delete(id);
            return RedirectToAction("Index", "Home");
        }
    }
}