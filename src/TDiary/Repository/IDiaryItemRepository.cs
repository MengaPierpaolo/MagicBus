using TDiary.Model;

namespace TDiary.Repository
{
    public interface IDiaryItemRepository<T> where T : DiaryItem
    {
        T Get(int id);

        void AddNew(T item);

        void SaveChanges(T item);

        void Delete(T chow);
    }
}
