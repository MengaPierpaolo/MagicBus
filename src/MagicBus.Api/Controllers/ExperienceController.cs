using MagicBus.Repository;
using Microsoft.AspNetCore.Mvc;

namespace MagicBus
{
    public abstract class ExperienceController : Controller
    {
        protected internal IExperienceRepository _repo;

        public ExperienceController(IExperienceRepository repo){
            _repo = repo;
        }
    }
}