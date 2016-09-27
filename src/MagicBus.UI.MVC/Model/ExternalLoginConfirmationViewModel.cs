using System.ComponentModel.DataAnnotations;
using MagicBus.Providers.ViewModel.Model;

namespace MagicBus
{
    public class ExternalLoginConfirmationViewModel : PageViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Display(Name ="User Name")]
        public string UserName { get; set; }
    }
}