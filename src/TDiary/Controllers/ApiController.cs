using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TDiary.Model;
using TDiary.Repository;

namespace TDiary
{
    public class ApiController : Controller
    {
        private readonly DiaryItemListRepository _repository;
        
        public ApiController(DiaryItemListRepository repository)
        {
            _repository = repository;
        }
        
        public IEnumerable<DiaryItem> AllExperiences()
        {
            return _repository.GetRecentExperiences();
        }
    }
}