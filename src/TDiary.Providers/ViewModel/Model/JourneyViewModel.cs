using System.Collections.Generic;
using System.Linq;

namespace TDiary.Providers.ViewModel.Model
{
    public class JourneyViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<ExperienceViewModel> Experiences{ get; set; }

        public int TripCount
        {
            get
            {
                return Experiences.Where(t => t.ExperienceType == "Trip").Count();
            }
        }

        public int ChowCount
        {
            get
            {
                return Experiences.Where(t => t.ExperienceType == "Chow").Count();
            }
        }

        public int SightCount
        {
            get
            {
                return Experiences.Where(t => t.ExperienceType == "Sight").Count();
            }
        }

        public int NapCount
        {
            get
            {
                return Experiences.Where(t => t.ExperienceType == "Nap").Count();
            }
        }

    }
}