using System.Collections.Generic;

namespace TDiary.Providers.ViewModel.Model
{
    public class JourneyListViewModel : PageViewModel
    {
        public IEnumerable<JourneyViewModel> Journeys { get; set; }
    }
}
