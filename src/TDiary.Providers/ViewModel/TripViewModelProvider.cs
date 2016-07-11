using Microsoft.Extensions.Localization;
using System.Threading.Tasks;
using TDiary.Model;
using TDiary.Providers.Location;
using TDiary.Providers.ViewModel.Model;

namespace TDiary.Providers.ViewModel
{
    public class TripViewModelProvider : ViewModelProvider<TripViewModel>, IViewModelProvider<Trip, TripViewModel>
    {
        private ILocationProvider _locationProvider;

        public TripViewModelProvider(ILocationProvider locationProvider, IStringLocalizer localizer) : base(localizer)
        {
            _locationProvider = locationProvider;
        }

        public async Task<TripViewModel> CreateAddViewModel()
        {
            var item = new TripViewModel(_localizer)
            {
                From = await _locationProvider.GetLastLocation()
            };

            return AddTitles(item);
        }

        public TripViewModel RefreshAddViewModel(TripViewModel item)
        {
            return AddTitles(item);
        }

        public TripViewModel RefreshEditViewModel(TripViewModel item)
        {
            return EditTitles(item);
        }
    }
}