using Microsoft.Extensions.Localization;
using System.Threading.Tasks;
using MagicBus.Model;
using MagicBus.Providers.Location;
using MagicBus.Providers.ViewModel.Model;
using System;

namespace MagicBus.Providers.ViewModel
{
    public class SightViewModelProvider : ViewModelProvider<SightViewModel>, IViewModelProvider<Sight, SightViewModel>
    {
        private ILocationProvider _locationProvider;

        public SightViewModelProvider(ILocationProvider locationProvider, IStringLocalizer localizer) : base(localizer)
        {
            _locationProvider = locationProvider;
        }

        public async Task<SightViewModel> CreateAddViewModel()
        {
            var item = new SightViewModel(_localizer)
            {
                Location = await _locationProvider.GetLastLocation()
            };

            return AddTitles(item);
        }

        public async Task<SightViewModel> RefreshAddViewModel(SightViewModel item)
        {
            item.Localize(_localizer);
            if (item.Date != DateTime.MinValue)
            {
                item.Location = await _locationProvider.GetLocation(item.Date);
            }
            return AddTitles(item);
        }

        public SightViewModel RefreshEditViewModel(SightViewModel item)
        {
            item.Localize(_localizer);
            return EditTitles(item);
        }
    }
}
