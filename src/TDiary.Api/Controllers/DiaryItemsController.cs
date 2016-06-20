using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TDiary.Model;
using TDiary.Repository;
using TDiary.Service;

namespace TDiary.Api
{
    [Route("api/[controller]")]
    public class DiaryItemsController : Controller
    {
        private readonly DiaryItemListRepository _diaryItemsRepo;
        private readonly IActivityOrderService _activityOrderService;

        public DiaryItemsController(DiaryItemListRepository diaryItemsRepo, IActivityOrderService activityOrderService)
        {
            _diaryItemsRepo = diaryItemsRepo;
            _activityOrderService = activityOrderService;
        }

        [HttpGet]
        public IEnumerable<DiaryItem> Recent()
        {
            return _diaryItemsRepo.GetRecentExperiences(PageSize.Five);
        }

        [HttpPut("{id}")]
        public IActionResult Order(int id, [FromBody]string order)
        {
            if (order == "Up")
            {
                _activityOrderService.OrderUp(id);
            }
            else
            {
                _activityOrderService.OrderDown(id);
            }
            return new OkResult();
        }
    }
}
