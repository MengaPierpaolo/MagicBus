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
                return Experiences.Where(t => t.Experience == "Trip").Count();
            }
        }
    }
}