using Microsoft.Extensions.Localization;
using System.Threading.Tasks;
using MagicBus.Model;
using MagicBus.Providers.Location;
using MagicBus.Providers.ViewModel.Model;
using System;

namespace MagicBus.Providers.ViewModel
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

        public async Task<TripViewModel> RefreshAddViewModel(TripViewModel item)
        {
            item.Localize(_localizer);
            if (item.Date != DateTime.MinValue)
            {
                item.From = await _locationProvider.GetLocation(item.Date);
            }
            return AddTitles(item);
        }

        public TripViewModel RefreshEditViewModel(TripViewModel item)
        {
            item.Localize(_localizer);
            return EditTitles(item);
        }
    }
}