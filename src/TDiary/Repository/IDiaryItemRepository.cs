using TDiary.Model;

namespace TDiary.Repository
{
    public interface IDiaryItemRepository<T> where T : DiaryItem
    {
        U Get<U>(int id) where U : DiaryItem; 

        void Add(T item);

        void SaveChanges(T item);

        void Delete(T chow);
    }
}
