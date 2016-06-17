using System;
using Microsoft.AspNetCore.Mvc;
using TDiary.Model;
using TDiary.Repository;

namespace TDiary.Api
{
    [Route("api/[Controller]")]
    public class TripController : DiaryItemController
    {
        public TripController(IDiaryItemRepository repo) : base(repo)
        {
        }

        [HttpPost]
        public IActionResult Create([FromBody]string value)
        {
            var item = new Trip(DateTime.Now, "Here", "There", ModeOfTransport.Bus);
            _repo.Add(item);
            // todo: return added item?
            return CreatedAtAction("Read", new { Controller = "Trip", id = 1 }, item);
        }

        [HttpGet("{id}")]
        public IActionResult Read(int id)
        {
            return new ObjectResult(_repo.Get<Trip>(id));
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody]string value)
        {
            var item = Trip.Create(id, DateTime.Now, "A", "B", ModeOfTransport.Train, 0);
            _repo.SaveChanges(item);
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _repo.Delete(Chow.Create(id));
        }
    }
}