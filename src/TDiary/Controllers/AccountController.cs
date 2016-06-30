using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Authentication;
using Microsoft.AspNetCore.Mvc;
using TDiary.Providers.ViewModel.Model;

namespace TDiary
{
    // TODO: The whole of this controller is just to prove concept.
    [ServiceFilter(typeof(LanguageActionFilter))]
    [AllowAnonymous]
    public class AccountController : Controller
    {
        public async Task<IActionResult> Login(string returnUrl = null)
        {
            const string Issuer = "https://magicbus.azurewebsites.net";
            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, "Jason", ClaimValueTypes.String, Issuer));
            var userIdentity = new ClaimsIdentity("MagicBusLogin");
            userIdentity.AddClaims(claims);
            var userPrincipal = new ClaimsPrincipal(userIdentity);

            await HttpContext.Authentication.SignInAsync("Cookie", userPrincipal,
                new AuthenticationProperties
                {
                    ExpiresUtc = DateTime.UtcNow.AddMinutes(20),
                    IsPersistent = false,
                    AllowRefresh = false
                });

            return RedirectToLocal(returnUrl);
        }

        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public async Task<IActionResult> ForceLogin(){
            const string Issuer = "https://magicbus.azurewebsites.net";
            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, "Jason", ClaimValueTypes.String, Issuer));
            claims.Add(new Claim(ClaimTypes.Role, "Administrator", ClaimValueTypes.String, Issuer));
            var userIdentity = new ClaimsIdentity("MagicBusLogin");
            userIdentity.AddClaims(claims);
            var userPrincipal = new ClaimsPrincipal(userIdentity);

            await HttpContext.Authentication.SignInAsync("Cookie", userPrincipal,
                new AuthenticationProperties
                {
                    ExpiresUtc = DateTime.UtcNow.AddMinutes(20),
                    IsPersistent = false,
                    AllowRefresh = false
                });

                return RedirectToAction("Index", "Home");
        }

        public IActionResult Forbidden(string returnUrl = null)
        {
            var vm = new HomeViewModel()
            {
                Title = "",
                Heading = "",
                RecentExperiences = new List<RecentExperienceViewModel>()
            };

            return View(vm);
        }
    }
}