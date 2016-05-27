using System.Collections.Generic;
using TDiary.Model;

namespace TDiary.ViewModels
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

        public IList<DiaryItem> Experiences { get; set; }
    }
}