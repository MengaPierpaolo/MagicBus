using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using TDiary.Providers.ViewModel.Model;

namespace TDiary
{
    [ServiceFilter(typeof(LanguageActionFilter))]
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager
        )
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [AllowAnonymous]
        public async Task<IActionResult> ForceLogin()
        {
            if (_signInManager.IsSignedIn(User))
            {
                await _signInManager.SignOutAsync();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        [AllowAnonymous]
        public IActionResult Login(string returnUrl = null)
        {
            return View(new LoginViewModel());
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel vm)
        {
            if (vm.LoginPressed)
            {
                if (vm.UserName != null && vm.Password != null)
                {
                    var result = await _signInManager.PasswordSignInAsync(vm.UserName, vm.Password, false, lockoutOnFailure: false);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
            }
            else
            {
                return RedirectToAction("Register", "Account");
            }

            return View(new LoginViewModel());
        }

        [AllowAnonymous]
        public IActionResult Register(string returnUrl = null)
        {
            return View(new LoginViewModel());
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(LoginViewModel vm)
        {
            var user = new ApplicationUser { UserName = vm.UserName, Email = vm.UserName };
            var result = await _userManager.CreateAsync(user, vm.Password);
            if (result.Succeeded)
            {
                await _signInManager.PasswordSignInAsync(vm.UserName, vm.Password, false, lockoutOnFailure: false);
                return RedirectToAction("Index", "Home");
            }

            return View(new LoginViewModel());
        }
    }
}