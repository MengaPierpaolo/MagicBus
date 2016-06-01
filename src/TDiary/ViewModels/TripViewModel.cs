using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TDiary.ViewModel
{
    public class TripViewModel : Activity
    {
        [Required]
        [Display(Name = "From")]
        public string From { get; set; }

        [Required]
        [Display(Name = "To")]
        public string To { get; set; }

        [Required]
        [Display(Name = "By")]
        public string ModeOfTransport { get; set; }

        public IEnumerable<SelectListItem> Transport { get; set; }
    }
}