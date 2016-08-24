using Microsoft.AspNetCore.Mvc;
using TDiary.Model;
using TDiary.Providers.ViewModel.Model;
using TDiary.Repository;

namespace TDiary.Api
{
    [Route("api/[Controller]")]
    public class TripController : ExperienceController
    {
        public TripController(IExperienceRepository repo) : base(repo) { }

        [HttpPost]
        public IActionResult Create([FromBody]TripViewModel value)
        {
            _repo.Add(new Trip(value.Date, value.From, value.To, value.By) {
                Rating = value.Rating,
                Journey = value.Journey });

            return new OkResult();
        }

        [HttpGet("{id}")]
        public IActionResult Read(int id)
        {
            return new ObjectResult(_repo.Get<Trip>(id));
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody]TripViewModel value)
        {
            _repo.SaveChanges(Trip.Create(
                id,
                value.Date,
                value.From,
                value.To,
                value.By,
                value.SavePosition,
                value.Rating,
                value.Journey));

            return new OkResult();
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _repo.Delete(Trip.Create(id));
        }
    }
}