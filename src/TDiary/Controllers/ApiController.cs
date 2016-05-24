using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TDiary.Model;

namespace TDiary
{
    public class ApiController : Controller
    {
        private readonly TestContext _context;
        
        public ApiController(TestContext context)
        {
            _context = context;
        }
        
        public IEnumerable<EFTest> GetSomeData()
        {
            return _context.Tests.ToList();
        }
    }
}