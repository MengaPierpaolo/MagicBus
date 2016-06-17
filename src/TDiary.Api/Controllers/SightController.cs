using System;
using Microsoft.AspNetCore.Mvc;
using TDiary.Model;
using TDiary.Repository;

namespace TDiary.Api
{
    public class SightController : DiaryItemController
    {
        public SightController(IDiaryItemRepository repo) : base(repo) {

        }

        [HttpPost]
        public IActionResult Create([FromBody]string value)
        {
            var item = new Sight(DateTime.Now, value);
            _repo.Add(item);
            // todo: return added item?
            return CreatedAtAction("Read", new { Controller = "Sight", id = 1 }, item);
        }

        [HttpGet("{id}")]
        public IActionResult Read(int id)
        {
            return new ObjectResult(_repo.Get<Sight>(id));
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody]string value)
        {
            var item = Sight.Create(id, DateTime.Now, value, "There", 0);
            _repo.SaveChanges(item);
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _repo.Delete(Sight.Create(id));
        }

    }
}