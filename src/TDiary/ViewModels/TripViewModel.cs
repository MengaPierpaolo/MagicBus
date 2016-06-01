using System.ComponentModel.DataAnnotations;
using TDiary.Model;

namespace TDiary.ViewModel
{
    public class TripViewModel : Activity
    {
        [Required]
        [Display(Name = "You travelled from")]
        public string From { get; set; }

        [Required]
        [Display(Name = "To")]
        public string To { get; set; }

        [Required]
        [Display(Name = "By")]
        public ModeOfTransport ModeOfTransport { get; set; }
    }
}