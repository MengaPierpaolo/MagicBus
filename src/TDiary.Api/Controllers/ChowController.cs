using Microsoft.AspNetCore.Mvc;
using TDiary.Model;
using TDiary.Repository;
using TDiary.Providers.ViewModel.Model;

namespace TDiary.Api
{
    [Route("api/[Controller]")]
    public class ChowController : DiaryItemController
    {
        public ChowController(IDiaryItemRepository repo) : base(repo) { }

        [HttpPost]
        public IActionResult Create([FromBody]ChowViewModel value)
        {
            _repo.Add(new Chow(value.Date, value.Description) { Location = value.Location });
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
            _repo.SaveChanges(Chow.Create(id, value.Date, value.Description, value.Location, value.SavePosition));
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _repo.Delete(Chow.Create(id));
        }
    }
}