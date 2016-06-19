using Microsoft.AspNetCore.Mvc;
using TDiary.Model;
using TDiary.Providers.ViewModel.Model;
using TDiary.Repository;

namespace TDiary.Api
{
    [Route("api/[Controller]")]
    public class SightController : DiaryItemController
    {
        public SightController(IDiaryItemRepository repo) : base(repo) { }

        [HttpPost]
        public IActionResult Create([FromBody]SightViewModel value)
        {
            _repo.Add(new Sight(value.Date, value.Name) { Location = value.Location });
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
            _repo.SaveChanges(Sight.Create(id, value.Date, value.Name, value.Location, value.SavePosition));
            return new OkResult();
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _repo.Delete(Sight.Create(id));
        }
    }
}