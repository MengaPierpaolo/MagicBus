using TDiary.Model;

namespace TDiary.Repository
{
    public interface IExperienceRepository
    {
        U Get<U>(int id) where U : Experience; 

        void Add(Experience item);

        void SaveChanges(Experience item);

        void Delete(Experience chow);
    }
}
