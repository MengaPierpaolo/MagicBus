using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TDiary.Model;
using TDiary.Repository;

namespace TDiary.Api
{
    [Route("api/[controller]")]
    public class DiaryItemController : Controller
    {
        private readonly DiaryItemListRepository _diaryItemsRepo;

        public DiaryItemController(DiaryItemListRepository diaryItemsRepo)
        {
            _diaryItemsRepo = diaryItemsRepo;
        }

        [HttpGet]
        public IEnumerable<DiaryItem> Recent()
        {
            return _diaryItemsRepo.GetRecentExperiences(PageSize.Five);
        }
    }
}
