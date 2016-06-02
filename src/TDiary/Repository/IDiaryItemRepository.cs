using TDiary.Model;

namespace TDiary.Repository
{
    public interface IDiaryItemRepository
    {
        U Get<U>(int id) where U : DiaryItem; 

        void Add(DiaryItem item);

        void SaveChanges(DiaryItem item);

        void Delete(DiaryItem chow);
    }
}
