using System.Collections.Generic;
using System.Threading.Tasks;
using TDiary.Model;
using TDiary.Providers.ViewModel.Model;

namespace TDiary
{
    public interface IApiProxy
    {
        void SetPath(string url);
        Task<T> Get<T>(int id) where T : ActivityViewModel;
        Task Add(DiaryItem item);
        Task Save(DiaryItem item);
        Task Delete<T>(int id) where T : DiaryItem;
        Task<IEnumerable<ExperienceViewModel>> GetRecent();
        Task PromoteActivity(int activityId);
        Task DemoteActivity(int activityId);
    }
}