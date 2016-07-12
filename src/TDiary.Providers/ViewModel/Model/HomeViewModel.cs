using Microsoft.Extensions.Localization;
using System.Collections.Generic;
using System.Linq;

namespace TDiary.Providers.ViewModel.Model
{
    public class HomeViewModel : PageViewModel
    {
        private readonly IEnumerable<ExperienceViewModel> _experiences;
        private readonly IStringLocalizer _localizer;

        public HomeViewModel(IEnumerable<ExperienceViewModel> experiences, IStringLocalizer localizer)
        {
            _localizer = localizer;
            _experiences = experiences;

            Title = _localizer.GetString("ApplicationTitle");
            Heading = _localizer.GetString("ApplicationHeading");

            SetupLocalization();
        }

        private void SetupLocalization()
        {
            foreach (var experience in _experiences)
            {
                experience.Localize(_localizer);
            }
        }

        public IEnumerable<ExperienceViewModel> RecentExperiences
        {
            get
            {
                return _experiences;
            }
        }

        public bool ShowRecentExperiences
        {
            get
            {
                return _experiences.ToList().Count > 0;
            }
        }
    }
}