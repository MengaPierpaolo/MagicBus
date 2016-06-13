using TDiary.Model;
using TDiary.ViewModel;

namespace TDiary
{
    public class NapViewModelProvider : IViewModelProvider<Nap, NapViewModel>
    {
        private ILocationProvider _locationProvider;

        public NapViewModelProvider(ILocationProvider locationProvider)
        {
            _locationProvider = locationProvider;
        }

        public NapViewModel CreateAddViewModel()
        {
            return new NapViewModel { Location = _locationProvider.GetLastLocation() }.WithAddTitles();
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