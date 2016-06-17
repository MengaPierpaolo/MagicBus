using TDiary.Repository;
using Microsoft.AspNetCore.Mvc;

namespace TDiary
{
    public class DiaryItemController : Controller
    {
        protected internal IDiaryItemRepository _repo;

        public DiaryItemController(IDiaryItemRepository repo){
            _repo = repo;
        }
    }
}