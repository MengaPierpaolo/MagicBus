using Microsoft.AspNetCore.Mvc;

namespace TDiary
{
    public class HomeController : Controller
    {
        [HttpGet("/")]
        public IActionResult Index() 
        {
            var vm = new HomeViewModel() { Title = "Hello World", Message = "Hello There Lovely MVC!" };
            return View(vm);    
        }
    }
    
    public class HomeViewModel
    {
        public string Title { get; internal set; }
        public string Message { get; internal set; }
    }
}