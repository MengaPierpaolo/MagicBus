using System.ComponentModel.DataAnnotations;
using TDiary.Providers.ViewModel.Model;

namespace TDiary
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