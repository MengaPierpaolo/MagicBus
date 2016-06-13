using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TDiary.Model;

namespace TDiary.Api
{
    [Route("api/[controller]")]
    public class DiaryItemController
    {
        [HttpGet]
        public IEnumerable<DiaryItem> Get()
        {
            return new List<DiaryItem> {
                new Chow(DateTime.Now, "Nosh") { Location = "Bed" },
                new Trip(DateTime.Now, "Bed", "Mali", ModeOfTransport.Plane),
                new Sight(DateTime.Now, "Baboons") { Location = "Mali" }
            };
        }
    }
}
