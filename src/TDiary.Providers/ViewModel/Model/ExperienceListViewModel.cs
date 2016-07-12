using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Localization;

namespace TDiary.Providers.ViewModel.Model
{
    public class ExperienceListViewModel : PageViewModel
    {
        private readonly IEnumerable<ExperienceViewModel> _experiences;
        private readonly IStringLocalizer _localizer;

        public ExperienceListViewModel(IEnumerable<ExperienceViewModel> experiences, IStringLocalizer localizer)
        {
            _localizer = localizer;
            _experiences = experiences;

            Title = _localizer.GetString("ExperienceListTitle");
            Heading = _localizer.GetString("ExperienceListHeading");

            SetupLocalization();
        }

        private void SetupLocalization()
        {
            foreach (var experience in _experiences)
            {
                experience.Localize(_localizer);
            }
        }

        public IEnumerable<ExperienceViewModel> Experiences
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
                return _experiences?.ToList().Count > 0;
            }
        }
    }
}