using Microsoft.Extensions.Localization;
using System.Threading.Tasks;
using TDiary.Model;
using TDiary.Providers.Location;
using TDiary.Providers.ViewModel.Model;

namespace TDiary.Providers.ViewModel
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

        public SightViewModel RefreshAddViewModel(SightViewModel item)
        {
            return AddTitles(item);
        }

        public SightViewModel RefreshEditViewModel(SightViewModel item)
        {
            return EditTitles(item);
        }
    }
}
