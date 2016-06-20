using System.ComponentModel.DataAnnotations;
using TDiary.Model;

namespace TDiary.Providers.ViewModel.Model
{
    public class TripViewModel : ActivityViewModel
    {
        [Required]
        [Display(Name = "You travelled from")]
        public string From { get; set; }

        [Required]
        [Display(Name = "You travelled to")]
        public string To { get; set; }

        [Required]
        [Display(Name = "Your mode of transport was")]
        public ModeOfTransport By { get; set; }
    }
}