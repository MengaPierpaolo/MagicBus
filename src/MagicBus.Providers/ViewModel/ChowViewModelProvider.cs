using System.Threading.Tasks;
using Microsoft.Extensions.Localization;
using MagicBus.Model;
using MagicBus.Providers.Location;
using MagicBus.Providers.ViewModel.Model;

namespace MagicBus.Providers.ViewModel
{
    public class ChowViewModelProvider : ViewModelProvider<ChowViewModel>, IViewModelProvider<Chow, ChowViewModel>
    {
        private ILocationProvider _locationProvider;

        public ChowViewModelProvider(ILocationProvider locationProvider, IStringLocalizer localizer) : base(localizer)
        {
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

        public ChowViewModel RefreshAddViewModel(ChowViewModel item)
        {
            item.Localize(_localizer);
            return AddTitles(item);
        }

        public ChowViewModel RefreshEditViewModel(ChowViewModel item)
        {
            item.Localize(_localizer);
            return EditTitles(item);
        }
    }
}