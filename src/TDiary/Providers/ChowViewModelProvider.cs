using TDiary.Model;
using TDiary.ViewModel;

namespace TDiary
{
    public class ChowViewModelProvider : IViewModelProvider<Chow, ChowViewModel>
    {
        private ILocationProvider _locationProvider;

        public ChowViewModelProvider(ILocationProvider locationProvider)
        {
            _locationProvider = locationProvider;
        }

        public ChowViewModel CreateAddViewModel()
        {
            return new ChowViewModel() { Location = _locationProvider.GetLastLocation() }.WithAddTitles();
        }

        public ChowViewModel CreateEditViewModel(Chow item)
        {
            return new ChowViewModel
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

        public ChowViewModel RefreshAddViewModel(ChowViewModel item)
        {
            return item.WithAddTitles();
        }

        public ChowViewModel RefreshEditViewModel(ChowViewModel item)
        {
            return item.WithEditTitles();
        }
    }
}