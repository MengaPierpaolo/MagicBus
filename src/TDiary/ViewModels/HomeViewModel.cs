using System.Collections.Generic;

namespace TDiary.ViewModel
{
    public class HomeViewModel
    {
        private string _title;

        public HomeViewModel(string title)
        {
            _title = title;
        }

        public string Title => _title;

        public string Heading { get; set; }

        public IEnumerable<Activity> Activities { get; set; }
    }
}