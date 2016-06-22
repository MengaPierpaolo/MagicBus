using System.Threading.Tasks;
using TDiary.Model;
using TDiary.Providers.Location;
using TDiary.Providers.ViewModel.Model;

namespace TDiary.Providers.ViewModel
{
    public class ChowViewModelProvider : IViewModelProvider<Chow, ChowViewModel>
    {
        private ILocationProvider _locationProvider;

        public ChowViewModelProvider(ILocationProvider locationProvider)
        {
            _locationProvider = locationProvider;
        }

        public async Task<ChowViewModel> CreateAddViewModel()
        {
            return new ChowViewModel() { Location = await _locationProvider.GetLastLocation() }.WithAddTitles();
        }

        public ChowViewModel RefreshAddViewModel(ChowViewModel item)
        {
            return item.WithAddTitles();
        }

        public ChowViewModel RefreshEditViewModel(ChowViewModel item)
        {
            return item.WithEditTitles();
        }
    }
}