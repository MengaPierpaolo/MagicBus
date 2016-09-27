using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using MagicBus.Model;
using MagicBus.Repository;

namespace MagicBus.Api.Controllers
{
    [Route("api/[controller]")]
    public class JourneysController : Controller
    {
        private readonly ExperienceListRepository _experienceListRepo;

        public JourneysController(ExperienceListRepository experienceListRepo)
        {
            _experienceListRepo = experienceListRepo;
        }

        [HttpGet]
        public IEnumerable<Journey> Journeys()
        {
            return _experienceListRepo.GetJourneys();
        }
    }
}
