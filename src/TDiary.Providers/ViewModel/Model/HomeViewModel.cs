using Microsoft.Extensions.Localization;
using System.Collections.Generic;

namespace TDiary.Providers.ViewModel.Model
{
    public class HomeViewModel : PageViewModel
    {
        private readonly ExperienceListViewModel _experienceList;

        public HomeViewModel(IEnumerable<ExperienceViewModel> experiences, IStringLocalizer localizer)
        {
            _experienceList = new ExperienceListViewModel(experiences, localizer, 0);

            Title = localizer.GetString("ApplicationTitle");
            Heading = localizer.GetString("ApplicationHeading");
        }

        public IEnumerable<ExperienceViewModel> RecentExperiences
        {
            get
            {
                return _experienceList.Experiences;
            }
        }

        public bool ShowRecentExperiences
        {
            get
            {
                return _experienceList.ShowRecentExperiences;
            }
        }
    }
}