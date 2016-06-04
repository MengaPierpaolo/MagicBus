using TDiary.Model;
using TDiary.ViewModel;

namespace TDiary
{
    public class SightViewModelProvider : IViewModelProvider<Sight, SightViewModel>
    {
        protected ILocationProvider _locationProvider;

        public SightViewModelProvider(ILocationProvider locationProvider)
        {
            _locationProvider = locationProvider;
        }

        public SightViewModel CreateAddViewModel()
        {
            var vm = new SightViewModel() { Location = _locationProvider.GetLastLocation() };
            vm.Title = "What a sight!";
            vm.Heading = "You've seen something funky";
            return vm;
        }

        public SightViewModel CreateEditViewModel(Sight item)
        {
            var vm = new SightViewModel { Id = item.Id, Date = item.Date, Location = item.Location, Name = item.Name, Experience = item.Experience };
            vm.Title = "Double Take?";
            vm.Heading = "Change what you saw.";
            return vm;
        }
    }
}
