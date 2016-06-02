using Microsoft.AspNetCore.Mvc;
using TDiary.Model;
using TDiary.Repository;

namespace TDiary
{
    public abstract class DiaryController<T> : Controller where T : DiaryItem
    {
        protected IDiaryItemRepository _repository;

        public DiaryController(IDiaryItemRepository context)
        {
            _repository = context;
        }
    }
}