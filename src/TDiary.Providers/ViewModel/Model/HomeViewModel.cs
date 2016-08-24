using Microsoft.Extensions.Localization;
using System.Collections.Generic;
using System.Linq;

namespace TDiary.Providers.ViewModel.Model
{
    public class HomeViewModel : PageViewModel
    {
        private readonly ExperienceListViewModel _experienceList;
        private readonly IEnumerable<JourneyViewModel> _journeys;

        public HomeViewModel(IEnumerable<ExperienceViewModel> experiences, IEnumerable<JourneyViewModel> journeys, IStringLocalizer localizer)
        {
            _experienceList = new ExperienceListViewModel(experiences, localizer, 0);
            _journeys = journeys;

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

        public IEnumerable<JourneyViewModel> Journeys
        {
            get
            {
                return _journeys;
            }
        }

        public bool ShowRecentJourneys
        {
            get
            {
                return Journeys.ToList().Count() > 0;
            }
        }
    }
}