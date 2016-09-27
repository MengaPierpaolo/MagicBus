using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MagicBus.Model;
using MagicBus.Repository;
using MagicBus.Service;

namespace MagicBus.Api
{
    [Route("api/[controller]")]
    public class ExperiencesController : Controller
    {
        private readonly ExperienceListRepository _experienceListRepo;
        private readonly IActivityOrderService _activityOrderService;

        public ExperiencesController(ExperienceListRepository experienceListRepo, IActivityOrderService activityOrderService)
        {
            _experienceListRepo = experienceListRepo;
            _activityOrderService = activityOrderService;
        }

        [HttpGet]
        public IEnumerable<Experience> Recent()
        {
            var x = _experienceListRepo.GetRecentExperiences(PageSize.Ten);
            return x;
        }

        [HttpGet, Route("[Action]/{page:int}")]
        public IEnumerable<Experience> PageNumber(int page = 0)
        {
            return _experienceListRepo.GetAllByPage(PageSize.Ten, page);
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
