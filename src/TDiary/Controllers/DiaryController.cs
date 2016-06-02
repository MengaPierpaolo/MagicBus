using Microsoft.AspNetCore.Mvc;
using TDiary.Model;
using TDiary.Repository;

namespace TDiary
{
    public class DiaryController<T> : Controller where T : DiaryItem
    {
        protected IDiaryItemRepository<T> _repository;

        public DiaryController(IDiaryItemRepository<T> context)
        {
            _repository = context;
        }
    }
}