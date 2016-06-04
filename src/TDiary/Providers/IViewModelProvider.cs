using TDiary.Model;
using TDiary.ViewModel;

namespace TDiary
{
    public interface IViewModelProvider<T, U> where T : DiaryItem where U : ActivityViewModel
    {
        U CreateAddViewModel();
        U CreateEditViewModel(T item);
    }
}