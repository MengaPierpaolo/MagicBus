using TDiary.Model;
using TDiary.ViewModel;

namespace TDiary
{
    public class SightViewModelProvider : IViewModelProvider<Sight, SightViewModel>
    {
        private ILocationProvider _locationProvider;

        public SightViewModelProvider(ILocationProvider locationProvider)
        {
            _locationProvider = locationProvider;
        }

        public SightViewModel CreateAddViewModel()
        {
            return new SightViewModel() { Location = _locationProvider.GetLastLocation() }.WithAddTitles();
        }

        public SightViewModel CreateEditViewModel(Sight item)
        {
            return new SightViewModel
            {
                Id = item.Id,
                Date = item.Date,
                Location = item.Location,
                Name = item.Name,
                Experience = item.Experience,
                SavePosition = item.SavePosition
            }
            .WithEditTitles();
        }

        public SightViewModel RefreshEditViewModel(SightViewModel item)
        {
            return item.WithEditTitles();
        }

        public SightViewModel RefreshAddViewModel(SightViewModel item)
        {
            return item.WithAddTitles();
        }
    }
}
