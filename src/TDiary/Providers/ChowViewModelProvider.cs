using TDiary.Model;
using TDiary.ViewModel;

namespace TDiary
{
    public class ChowViewModelProvider : IViewModelProvider<Chow, ChowViewModel>
    {
        protected ILocationProvider _locationProvider;

        public ChowViewModelProvider(ILocationProvider locationProvider)
        {
            _locationProvider = locationProvider;
        }

        public ChowViewModel CreateAddViewModel()
        {
            var vm = new ChowViewModel() { Location = _locationProvider.GetLastLocation() };
            vm.Title = "Had some Chow?";
            vm.Heading = "Yum, add it to the list!";
            return vm;
        }

        public ChowViewModel CreateEditViewModel(Chow item)
        {
            var vm = new ChowViewModel { Id = item.Id, Date = item.Date, Location = item.Location, Description = item.Description, Experience = item.Experience };
            vm.Title = "Chow mixed up?";
            vm.Heading = "Edit the details then!";
            return vm;
        }
    }
}