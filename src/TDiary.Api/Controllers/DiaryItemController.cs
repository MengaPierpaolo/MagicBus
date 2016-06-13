using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TDiary.Model;
using TDiary.Repository;

namespace TDiary.Api
{
    [Route("api/[controller]")]
    public class DiaryItemController
    {
        private readonly DiaryItemListRepository _repo;

        public DiaryItemController(DiaryItemListRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IEnumerable<DiaryItem> Get()
        {
            return _repo.GetRecentExperiences(PageSize.Five);
        }
    }
}
