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

        public IActionResult Add()
        {
            return View(_apiProxy.GetAddViewModel());
        }

        public IActionResult Edit(int id)
        {
            return View(_apiProxy.Get(id));
        }

        public IActionResult Delete(int id)
        {
            _apiProxy.Delete(id);
            return RedirectToAction("Index", "Home");
        }
    }
}