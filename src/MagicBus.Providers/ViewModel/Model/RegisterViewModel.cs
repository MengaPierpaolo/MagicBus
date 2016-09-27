using Microsoft.Extensions.Localization;
using System.ComponentModel.DataAnnotations;

namespace MagicBus.Providers.ViewModel.Model
{
    public class RegisterViewModel : PageViewModel
    {
        internal RegisterViewModel() { }
        public RegisterViewModel(IStringLocalizer localizer)
        {
            Title = localizer.GetString("ApplicationTitle");
            Heading = localizer.GetString("ApplicationHeading");
        }

        [Required]
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Please ensure you use a valid email address")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The password must be at least 6 and at max {1} characters long.")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

}
