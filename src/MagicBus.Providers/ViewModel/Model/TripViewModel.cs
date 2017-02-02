using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Localization;
using MagicBus.Model;

namespace MagicBus.Providers.ViewModel.Model
{
    public class TripViewModel : ActivityViewModel
    {
        public TripViewModel() { }
        public TripViewModel(IStringLocalizer _localizer) : base(_localizer) { }

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