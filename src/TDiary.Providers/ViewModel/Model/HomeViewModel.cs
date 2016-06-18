using System.Collections.Generic;
using System.Linq;

namespace TDiary.Providers.ViewModel.Model
{
    public class HomeViewModel : PageViewModel
    {
        public IEnumerable<RecentExperienceViewModel> RecentExperiences { get; set; }

        public bool ShowRecentExperiences
        {
            get
            {
                return RecentExperiences.ToList().Count > 0;
            }
        }
    }
}