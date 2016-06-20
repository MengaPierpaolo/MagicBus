using Microsoft.AspNetCore.Mvc;
using TDiary.Model;
using TDiary.Providers.ViewModel.Model;
using TDiary.Repository;

namespace TDiary.Api
{
    [Route("api/[Controller]")]

    public class NapController : DiaryItemController
    {
        public NapController(IDiaryItemRepository repo) : base(repo) { }

        [HttpPost]
        public IActionResult Create([FromBody]NapViewModel value)
        {
            _repo.Add(new Nap(value.Date, value.Description) { Location = value.Location });
            return new OkResult();
        }

        [HttpGet("{id}")]
        public IActionResult Read(int id)
        {
            return new ObjectResult(_repo.Get<Nap>(id));
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody]NapViewModel value)
        {
            _repo.SaveChanges(Nap.Create(id, value.Date, value.Description, value.Location, value.SavePosition));
            return new OkResult();
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _repo.Delete(Nap.Create(id));
        }
    }
}