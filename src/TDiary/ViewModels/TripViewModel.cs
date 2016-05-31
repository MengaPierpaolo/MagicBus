using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TDiary.ViewModel
{
    public class TripViewModel : Activity
    {
        [Required]
        public string From { get; set; }

        [Required]
        public string To { get; set; }

        [Required]
        public string ModeOfTransport { get; set; }

        public IEnumerable<SelectListItem> Transport { get; set; }
    }
}