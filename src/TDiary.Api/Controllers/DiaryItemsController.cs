using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TDiary.Model;
using TDiary.Repository;

namespace TDiary.Api
{
    [Route("api/[controller]")]
    public class DiaryItemsController : Controller
    {
        private readonly DiaryItemListRepository _diaryItemsRepo;

        public DiaryItemsController(DiaryItemListRepository diaryItemsRepo)
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
