namespace TDiary.Providers.ViewModel.Model
{
    public class LoginViewModel : PageViewModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string SubmitButtonUsed { get; set; }

        public bool LoginPressed
        {
            get
            {
                return this.SubmitButtonUsed == "Log in";
            }
        }
    }
}
