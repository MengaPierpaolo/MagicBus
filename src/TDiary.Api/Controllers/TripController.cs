using System;
using Microsoft.AspNetCore.Mvc;
using TDiary.Model;
using TDiary.Repository;

namespace TDiary.Api
{
    [Route("api/[Controller]")]
    public class TripController : Controller
    {
        private readonly IDiaryItemRepository _diaryItemRepo;

        public TripController(IDiaryItemRepository repo)
        {
            _diaryItemRepo = repo;
        }

        [HttpPost]
        public IActionResult Create([FromBody]string value)
        {
            var item = new Trip(DateTime.Now, "Here", "There", ModeOfTransport.Bus);
            _diaryItemRepo.Add(item);
            // todo: return added item?
            return CreatedAtAction("Read", new { Controller = "Trip", id = 1 }, item);
        }

        [HttpGet("{id}")]
        public IActionResult Read(int id)
        {
            return new ObjectResult(_diaryItemRepo.Get<Trip>(id));
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody]string value)
        {
            var item = Trip.Create(id, DateTime.Now, "A", "B", ModeOfTransport.Train, 0);
            _diaryItemRepo.SaveChanges(item);
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _diaryItemRepo.Delete(Chow.Create(id));
        }
    }
}