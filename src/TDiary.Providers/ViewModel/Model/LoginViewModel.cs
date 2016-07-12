using System.ComponentModel.DataAnnotations;

namespace TDiary.Providers.ViewModel.Model
{
    public class LoginViewModel : PageViewModel
    {
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
