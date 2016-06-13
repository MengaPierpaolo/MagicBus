using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace TDiary.Api
{
    [Route("api/[controller]")]
    public class DiaryItemController
    {
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] {"Whoat you did was awesome!", "And you also did something groovy"};
        }
    }
}
