using System.Threading.Tasks;
using Microsoft.Extensions.Localization;
using TDiary.Model;
using TDiary.Providers.Location;
using TDiary.Providers.ViewModel.Model;

namespace TDiary.Providers.ViewModel
{
    public class ChowViewModelProvider : IViewModelProvider<Chow, ChowViewModel>
    {
        private ILocationProvider _locationProvider;
        private IStringLocalizer _localizer;

        public ChowViewModelProvider(ILocationProvider locationProvider, IStringLocalizer localizer)
        {
            _locationProvider = locationProvider;
            _localizer = localizer;
        }

        public async Task<ChowViewModel> CreateAddViewModel()
        {
            var vm = new ChowViewModel()
            {
                Location = await _locationProvider.GetLastLocation()
            }
            .WithAddTitles(_localizer);

            return vm;
        }

        public ChowViewModel RefreshAddViewModel(ChowViewModel item)
        {
            return item.WithAddTitles(_localizer);
        }

        public ChowViewModel RefreshEditViewModel(ChowViewModel item)
        {
            return item.WithEditTitles(_localizer);
        }
    }
}