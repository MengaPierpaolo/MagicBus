using System.Collections.Generic;

namespace MagicBus.Providers.ViewModel.Model
{
    public class JourneyListViewModel : PageViewModel
    {
        public IEnumerable<JourneyViewModel> Journeys { get; set; }
    }
}
