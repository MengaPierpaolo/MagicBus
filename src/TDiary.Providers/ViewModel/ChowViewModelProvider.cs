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

        public ChowViewModel CreateEditViewModel(Chow item)
        {
            return new ChowViewModel
            {
                Id = item.Id,
                Date = item.Date,
                Location = item.Location,
                Description = item.Description,
                Experience = item.Experience,
                SavePosition = item.SavePosition
            }
            .WithEditTitles();
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