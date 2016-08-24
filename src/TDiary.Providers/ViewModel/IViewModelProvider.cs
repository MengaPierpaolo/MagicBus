using System.Threading.Tasks;
using TDiary.Model;
using TDiary.Providers.ViewModel.Model;

namespace TDiary.Providers.ViewModel
{
    public interface IViewModelProvider<T, U> where T : Experience where U : ActivityViewModel
    {
        Task<U> CreateAddViewModel();
        U RefreshAddViewModel(U item);
        U RefreshEditViewModel(U item);
    }
}