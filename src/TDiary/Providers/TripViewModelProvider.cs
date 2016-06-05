using TDiary.Model;
using TDiary.ViewModel;

namespace TDiary
{
    public class TripViewModelProvider : IViewModelProvider<Trip, TripViewModel>
    {
        private ILocationProvider _locationProvider;

        public TripViewModelProvider(ILocationProvider locationProvider)
        {
            _locationProvider = locationProvider;
        }
        
        public TripViewModel CreateAddViewModel()
        {
            var vm = new TripViewModel() { From = _locationProvider.GetLastLocation() };
            vm.Title = "Life's a Journey!";
            vm.Heading = "Add your travel detail.";
            return vm;
        }

        public TripViewModel CreateEditViewModel(Trip item)
        {
            var vm = new TripViewModel { Id = item.Id, Date = item.Date, From = item.From, To = item.To, ModeOfTransport = item.By, SavePosition = item.SavePosition };
            vm.Title = "Lost?";
            vm.Heading = "Edit your travel detail.";
            return vm;
        }
    }
}