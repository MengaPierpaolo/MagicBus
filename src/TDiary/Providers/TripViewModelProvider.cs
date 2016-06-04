using TDiary.Model;
using TDiary.ViewModel;

namespace TDiary
{
    public class TripViewModelProvider : IViewModelProvider<Trip, TripViewModel>
    {
        protected ILocationProvider _locationProvider;

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
            var vm = new TripViewModel { Id = item.Id, From = item.From, To = item.To, ModeOfTransport = item.By };
            vm.Title = "Lost?";
            vm.Heading = "Edit your travel detail.";
            return vm;
        }
    }
}