using System;
using Microsoft.AspNetCore.Mvc;
using TDiary.Model;
using TDiary.Repository;

namespace TDiary.Api
{
    [Route("api/[Controller]")]
    public class ChowController : DiaryItemController
    {
        public ChowController(IDiaryItemRepository repo) : base(repo)
        {

        }

        [HttpPost]
        public IActionResult Create([FromBody]string value)
        {
            var item = new Chow(DateTime.Now, value);
            _repo.Add(item);
            // todo: return added item?
            return CreatedAtAction("Read", new { Controller = "Chow", id = 1 }, item);
        }

        [HttpGet("{id}")]
        public IActionResult Read(int id)
        {
            return new ObjectResult(_repo.Get<Chow>(id));
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody]Chow value)
        {
            var item = Chow.Create(id, value.Date, value.Description, value.Location, 0);
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