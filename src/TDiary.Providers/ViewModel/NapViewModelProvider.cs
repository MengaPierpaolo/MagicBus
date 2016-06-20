using System.Threading.Tasks;
using TDiary.Model;
using TDiary.Providers.Location;
using TDiary.Providers.ViewModel.Model;

namespace TDiary.Providers.ViewModel
{
    public class NapViewModelProvider : IViewModelProvider<Nap, NapViewModel>
    {
        private ILocationProvider _locationProvider;

        public NapViewModelProvider(ILocationProvider locationProvider)
        {
            _locationProvider = locationProvider;
        }

        public async Task<NapViewModel> CreateAddViewModel()
        {
            return new NapViewModel { Location = await _locationProvider.GetLastLocation() }.WithAddTitles();
        }

        public NapViewModel CreateEditViewModel(Nap item)
        {
            return new NapViewModel
            {
                Id = item.Id,
                Date = item.Date,
                Location = item.Location,
                Description = item.Description,
                Experience = item.Experience,
                SavePosition = item.SavePosition
            }
            .WithEditTitles();
        }

        public NapViewModel RefreshEditViewModel(NapViewModel item)
        {
            return item.WithEditTitles();
        }

        public NapViewModel RefreshAddViewModel(NapViewModel item)
        {
            return item.WithAddTitles();
        }
    }
}
