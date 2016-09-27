using Microsoft.AspNetCore.Mvc;
using MagicBus.Model;
using MagicBus.Providers.ViewModel.Model;
using MagicBus.Repository;

namespace MagicBus.Api
{
    [Route("api/[Controller]")]
    public class SightController : ExperienceController
    {
        public SightController(IExperienceRepository repo) : base(repo) { }

        [HttpPost]
        public IActionResult Create([FromBody]SightViewModel value)
        {
            _repo.Add(new Sight(value.Date, value.Name) {
                Location = value.Location,
                Rating = value.Rating,
                Journey = value.Journey });

            return new OkResult();
        }

        [HttpGet("{id}")]
        public IActionResult Read(int id)
        {
            return new ObjectResult(_repo.Get<Sight>(id));
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody]SightViewModel value)
        {
            _repo.SaveChanges(Sight.Create(
                id,
                value.Date,
                value.Name,
                value.Location,
                value.SavePosition,
                value.Rating,
                value.Journey));

            return new OkResult();
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _repo.Delete(Sight.Create(id));
        }
    }
}