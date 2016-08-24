using TDiary.Repository;
using Microsoft.AspNetCore.Mvc;

namespace TDiary
{
    public abstract class ExperienceController : Controller
    {
        protected internal IExperienceRepository _repo;

        public ExperienceController(IExperienceRepository repo){
            _repo = repo;
        }
    }
}