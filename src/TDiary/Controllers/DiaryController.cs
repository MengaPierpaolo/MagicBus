using Microsoft.AspNetCore.Mvc;

namespace TDiary
{
    public class DiaryController : Controller
    {
        protected readonly DiaryContext _context;

        public DiaryController(DiaryContext context)
        {
            _context = context;
        }
    }
}