namespace TDiary.ViewModels
{
    public class HomeViewModel
    {
        private string _title;

        public HomeViewModel(string title)
        {
            _title = title;
        }

        public string Title {
            get
            {
                return _title;
            }
        }

        public string Heading { get; set; }
        public string Message { get; set; }
    }
}
