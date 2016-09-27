using Microsoft.Extensions.Localization;
using System.Threading.Tasks;
using MagicBus.Model;
using MagicBus.Providers.Location;
using MagicBus.Providers.ViewModel.Model;

namespace MagicBus.Providers.ViewModel
{
    public class NapViewModelProvider : ViewModelProvider<NapViewModel>, IViewModelProvider<Nap, NapViewModel>
    {
        private ILocationProvider _locationProvider;

        public NapViewModelProvider(ILocationProvider locationProvider, IStringLocalizer localizer) : base(localizer)
        {
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

        public NapViewModel RefreshAddViewModel(NapViewModel item)
        {
            item.Localize(_localizer);
            return AddTitles(item);
        }

        public NapViewModel RefreshEditViewModel(NapViewModel item)
        {
            item.Localize(_localizer);
            return EditTitles(item);
        }
    }
}
