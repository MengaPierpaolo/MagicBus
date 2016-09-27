using System.Threading.Tasks;
using MagicBus.Model;
using MagicBus.Providers.ViewModel.Model;

namespace MagicBus.Providers.ViewModel
{
    public interface IViewModelProvider<T, U> where T : Experience where U : ActivityViewModel
    {
        Task<U> CreateAddViewModel();
        U RefreshAddViewModel(U item);
        U RefreshEditViewModel(U item);
    }
}