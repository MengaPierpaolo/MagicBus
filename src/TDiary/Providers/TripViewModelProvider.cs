using TDiary.Model;
using TDiary.ViewModel;

namespace TDiary
{
    public class TripViewModelProvider : IViewModelProvider<Trip, TripViewModel>
    {
        private ILocationProvider _locationProvider;

        public TripViewModelProvider(ILocationProvider locationProvider)
        {
            _locationProvider = locationProvider;
        }

        public TripViewModel CreateAddViewModel()
        {
            return new TripViewModel() { From = _locationProvider.GetLastLocation() }.WithAddTitles();
        }

        public TripViewModel CreateEditViewModel(Trip item)
        {
            return new TripViewModel
            {
                Id = item.Id,
                Date = item.Date,
                From = item.From,
                To = item.To,
                ModeOfTransport = item.By,
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