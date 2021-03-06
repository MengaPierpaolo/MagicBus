using System.Collections.Generic;
using System.Threading.Tasks;
using MagicBus.Model;
using MagicBus.Providers.ViewModel.Model;

namespace MagicBus
{
    public interface IApiProxy
    {
        void SetPath(string url);
        Task<T> Get<T>(int id) where T : ActivityViewModel;
        Task Add(Experience item);
        Task Save(Experience item);
        Task Delete<T>(int id) where T : Experience;
        Task<IEnumerable<ExperienceViewModel>> GetRecent();
        Task<IEnumerable<JourneyViewModel>> GetJourneys();
        Task<IEnumerable<ExperienceViewModel>> GetAllByPage(int pageSize, int page = 0);
        Task PromoteActivity(int activityId);
        Task DemoteActivity(int activityId);
    }
}