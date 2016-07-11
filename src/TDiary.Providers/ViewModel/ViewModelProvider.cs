using Microsoft.Extensions.Localization;
using TDiary.Providers.ViewModel.Model;

namespace TDiary.Providers.ViewModel
{
    public abstract class ViewModelProvider<T> where T : ActivityViewModel
    {
        protected IStringLocalizer _localizer;

        public ViewModelProvider(IStringLocalizer localizer)
        {
            _localizer = localizer;
        }

        protected T AddTitles(T item)
        {
            var x = item.GetType().Name.Replace("ViewModel", string.Empty);
            item.Title = _localizer.GetString(x + "Title.Add");
            item.Heading = _localizer.GetString(x + "Heading.Add");
            return item;
        }

        protected T EditTitles(T item)
        {
            var x = item.GetType().Name.Replace("ViewModel", string.Empty);
            item.Title = _localizer.GetString(x + "Title.Edit");
            item.Heading = _localizer.GetString(x + "Heading.Edit");
            return item;
        }
    }
}
