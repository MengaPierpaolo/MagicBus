using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TDiary.Model;
using TDiary.Repository;

namespace TDiary.Api.Controllers
{
    [Route("api/[controller]")]
    public class JourneysController : Controller
    {
        private readonly DiaryItemListRepository _journeyListRepo;

        public JourneysController(DiaryItemListRepository journeyListRepo)
        {
            _journeyListRepo = journeyListRepo;
        }

        [HttpGet]
        public IEnumerable<Journey> Journeys()
        {
            return _journeyListRepo.GetJourneys();
        }
    }
}
