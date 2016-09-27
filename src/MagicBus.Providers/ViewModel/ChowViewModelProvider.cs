using System.Threading.Tasks;
using Microsoft.Extensions.Localization;
using MagicBus.Model;
using MagicBus.Providers.Location;
using MagicBus.Providers.LastDate;
using MagicBus.Providers.ViewModel.Model;
using System;

namespace MagicBus.Providers.ViewModel
{
    public class ChowViewModelProvider : ViewModelProvider<ChowViewModel>, IViewModelProvider<Chow, ChowViewModel>
    {
        private ILocationProvider _locationProvider;
        private ILastDateProvider _dateProvider;

        public ChowViewModelProvider(
            ILocationProvider locationProvider,
            ILastDateProvider dateProvider,
            IStringLocalizer localizer
            ) : base(localizer)
        {
            _dateProvider = dateProvider;
            _locationProvider = locationProvider;
        }

        public async Task<ChowViewModel> CreateAddViewModel()
        {
            var item = new ChowViewModel(_localizer)
            {
                Location = await _locationProvider.GetLastLocation()
            };

            return AddTitles(item);
        }

        public async Task<ChowViewModel> RefreshAddViewModel(ChowViewModel item)
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

        public ChowViewModel RefreshEditViewModel(ChowViewModel item)
        {
            item.Localize(_localizer);
            return EditTitles(item);
        }
    }
}