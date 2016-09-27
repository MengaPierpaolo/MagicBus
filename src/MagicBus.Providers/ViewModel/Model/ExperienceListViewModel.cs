using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Localization;

namespace MagicBus.Providers.ViewModel.Model
{
    public class ExperienceListViewModel : PageViewModel
    {
        private readonly IEnumerable<ExperienceViewModel> _experiences;
        private readonly IStringLocalizer _localizer;
        private readonly int _pageNumber;

        public ExperienceListViewModel(IEnumerable<ExperienceViewModel> experiences, IStringLocalizer localizer, int pageNumber = 0)
        {
            _localizer = localizer;
            _experiences = experiences;
            _pageNumber = pageNumber;

            Title = _localizer.GetString("ExperienceListTitle");
            Heading = _localizer.GetString("ExperienceListHeading");

            SetupLocalization();
            SetupMoveability();
        }

        private void SetupMoveability()
        {
            // get the days
            var firstOnes = from element in _experiences
                            group element by element.Date
                    into groups
                            select groups.OrderBy(p => p.SavePosition).First();

            // get the lowest on the day
            var lastOnes = from element in _experiences
                           group element by element.Date
                    into groups
                           select groups.OrderBy(p => p.SavePosition).Last();

            foreach (var experience in _experiences)
            {
                if (firstOnes.Contains(experience))
                {
                    experience.IsFirstOfTheDay = true;
                }
                if (lastOnes.Contains(experience))
                {
                    experience.IsLastOfTheDay = true;
                }
            }
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

        public int PageNumber
        {
            get
            {
                return _pageNumber;
            }
        }

        public bool IsFirstPage
        {
            get
            {
                return PageNumber == 0;
            }
        }

        public bool IsLastPage
        {
            get
            {
                return _experiences.Count() < 10;
            }
        }
    }
}