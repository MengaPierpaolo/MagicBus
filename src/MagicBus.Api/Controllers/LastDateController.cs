using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MagicBus.Providers.LastDate;
using System;

namespace MagicBus.Api
{
    [Route("api/[controller]")]
    public class LastDateController : Controller
    {
        private readonly ILastDateProvider _dateProvider;

        public LastDateController(ILastDateProvider dateProvider)
        {
            _dateProvider = dateProvider;
        }

        [HttpGet]
        public async Task<DateTime> Get()
        {
            return await _dateProvider.GetLastDate();
        }
    }
}