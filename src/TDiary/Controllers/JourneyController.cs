using Microsoft.AspNetCore.Mvc;
using TDiary.Providers.ViewModel.Model;

namespace TDiary.Controllers
{
    public class JourneyController : Controller
    {
        public IActionResult Index()
        {
            var vm = new JourneyListViewModel
            {
                Title = "Your Journeys",
                Heading = "Edit your journeys!"
            };

            return View(vm);
        }
    }
}
