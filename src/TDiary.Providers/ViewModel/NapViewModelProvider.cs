using Microsoft.Extensions.Localization;
using System.Threading.Tasks;
using TDiary.Model;
using TDiary.Providers.Location;
using TDiary.Providers.ViewModel.Model;

namespace TDiary.Providers.ViewModel
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
            var item = new NapViewModel
            {
                Location = await _locationProvider.GetLastLocation()
            };

            return AddTitles(item);
        }

        public NapViewModel RefreshAddViewModel(NapViewModel item)
        {
            return AddTitles(item);
        }

        public NapViewModel RefreshEditViewModel(NapViewModel item)
        {
            return EditTitles(item);
        }
    }
}
