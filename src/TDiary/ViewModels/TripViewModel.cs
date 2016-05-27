using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TDiary.ViewModel
{
    public class TripViewModel : Activity
    {
        public string From { get; set; }
        public string To { get; set; }
        public string ModeOfTransport { get; set; }
        public IEnumerable<SelectListItem> Transport { get; set; } 
    }
}