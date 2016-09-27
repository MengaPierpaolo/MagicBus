using Microsoft.Extensions.Localization;
using System.Threading.Tasks;
using MagicBus.Model;
using MagicBus.Providers.Location;
using MagicBus.Providers.ViewModel.Model;
using System;
using MagicBus.Providers.LastDate;

namespace MagicBus.Providers.ViewModel
{
    public class NapViewModelProvider : ViewModelProvider<NapViewModel>, IViewModelProvider<Nap, NapViewModel>
    {
        private ILocationProvider _locationProvider;
        private ILastDateProvider _dateProvider;

        public NapViewModelProvider(
            ILocationProvider locationProvider,
            ILastDateProvider dateProvider,
            IStringLocalizer localizer
        ) : base(localizer)
        {
            _dateProvider = dateProvider;
            _locationProvider = locationProvider;
        }

        public async Task<NapViewModel> CreateAddViewModel()
        {
            var item = new NapViewModel(_localizer)
            {
                Location = await _locationProvider.GetLastLocation()
            };

            return AddTitles(item);
        }

        public async Task<NapViewModel> RefreshAddViewModel(NapViewModel item)
        {
            item.Localize(_localizer);

            if (item.LocationPressed)
            {
                if (item.Date != DateTime.MinValue)
                {
                    item.Location = await _locationProvider.GetLocation(item.Date);
                }
            }

            if (item.DatePressed)
            {
                item.Date = await _dateProvider.GetLastDate();
            }

            return AddTitles(item);
        }

        public NapViewModel RefreshEditViewModel(NapViewModel item)
        {
            item.Localize(_localizer);
            return EditTitles(item);
        }
    }
}
