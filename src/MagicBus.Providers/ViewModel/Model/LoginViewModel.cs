using Microsoft.Extensions.Localization;
using System.ComponentModel.DataAnnotations;

namespace MagicBus.Providers.ViewModel.Model
{
    public class LoginViewModel : PageViewModel
    {
        internal LoginViewModel() { }
        public LoginViewModel(IStringLocalizer localizer)
        {
            Title = localizer.GetString("ApplicationTitle");
            Heading = localizer.GetString("ApplicationHeading");
        }

        [Required]
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

        public string SubmitButtonUsed { get; set; }

        public bool LoginPressed
        {
            get
            {
                return SubmitButtonUsed == "Log in";
            }
        }
    }
}
