using Microsoft.AspNetCore.Mvc;

namespace TDiary
{
    public class HomeController : Controller
    {
        public IActionResult Index() 
        {
            var vm = new HomeViewModel()
            {
                Title = "ASP.Net Core - TDiary",
                Heading = "Funky App!",
                Message = "Hello There Groovy ASP.NET Core MVC!"
            };

            return View(vm);    
        }
    }
    
    public class HomeViewModel
    {
        public string Title { get; internal set; }
        public string Heading { get; set; }
        public string Message { get; internal set; }
    }
}