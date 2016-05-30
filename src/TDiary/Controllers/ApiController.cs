using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TDiary.Model;

namespace TDiary
{
    public class ApiController : Controller
    {
        private readonly DiaryContext _context;
        
        public ApiController(DiaryContext context)
        {
            _context = context;
        }
        
        public IEnumerable<DiaryItem> AllExperiences()
        {
            return _context.Experiences.ToList();
        }
    }
}