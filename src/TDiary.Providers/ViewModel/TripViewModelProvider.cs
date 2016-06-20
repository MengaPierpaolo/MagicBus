using System.Threading.Tasks;
using TDiary.Model;
using TDiary.Providers.Location;
using TDiary.Providers.ViewModel.Model;

namespace TDiary.Providers.ViewModel
{
    public class TripViewModelProvider : IViewModelProvider<Trip, TripViewModel>
    {
        private ILocationProvider _locationProvider;

        public TripViewModelProvider(ILocationProvider locationProvider)
        {
            _locationProvider = locationProvider;
        }

        public async Task<TripViewModel> CreateAddViewModel()
        {
            return new TripViewModel() { From = await _locationProvider.GetLastLocation() }.WithAddTitles();
        }

        public TripViewModel CreateEditViewModel(Trip item)
        {
            return new TripViewModel
            {
                Id = item.Id,
                Date = item.Date,
                From = item.From,
                To = item.To,
                By = item.By,
                SavePosition = item.SavePosition
            }
            .WithEditTitles();
        }

        public TripViewModel RefreshAddViewModel(TripViewModel item)
        {
            return item.WithAddTitles();
        }

        public TripViewModel RefreshEditViewModel(TripViewModel item)
        {
            return item.WithEditTitles();
        }
    }
}