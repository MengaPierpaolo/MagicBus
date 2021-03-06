using Microsoft.AspNetCore.Mvc;
using MagicBus.Model;
using MagicBus.Repository;
using MagicBus.Providers.ViewModel.Model;

namespace MagicBus.Api
{
    [Route("api/[Controller]")]
    public class ChowController : ExperienceController
    {
        public ChowController(IExperienceRepository repo) : base(repo) { }

        [HttpPost]
        public IActionResult Create([FromBody]ChowViewModel value)
        {
            _repo.Add(new Chow(value.Date, value.Description) {
                Location = value.Location,
                Rating = value.Rating,
                Journey = value.Journey });

            return new OkResult();
        }

        [HttpGet("{id}")]
        public IActionResult Read(int id)
        {
            return new ObjectResult(_repo.Get<Chow>(id));
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody]ChowViewModel value)
        {
            _repo.SaveChanges(Chow.Create(
                id,
                value.Date,
                value.Description,
                value.Location,
                value.SavePosition,
                value.Rating,
                value.Journey));

            return new OkResult();
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _repo.Delete(Chow.Create(id));
        }
    }
}