using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
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

        public string Title {
            get
            {
                return _title;
            }
        }

        public string Heading { get; set; }
        public string Message { get; set; }
        public IList<EFTest> EFTests { get; set; }
        public IEnumerable<SelectListItem> EFTestsAsSelectListItems {
            get
            {
                return EFTests.Select(u => new SelectListItem
                {
                    Text = u.SomeText,
                    Value = u.Id.ToString()
                });
            }
        }
    }
}
