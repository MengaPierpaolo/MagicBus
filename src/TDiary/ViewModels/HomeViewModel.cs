using System.Collections.Generic;
using System.Linq;

namespace TDiary.ViewModel
{
    public class HomeViewModel : PageViewModel
    {
        public IEnumerable<ActivityViewModel> Activities { get; set; }

        public bool ShowRecentExperiences
        {
            get
            {
                return Activities.ToList().Count > 0;
            }
        }
    }
}