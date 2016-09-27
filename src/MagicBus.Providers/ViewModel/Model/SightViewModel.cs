using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Localization;

namespace MagicBus.Providers.ViewModel.Model
{
    public class SightViewModel : ActivityViewModel
    {
        internal SightViewModel() { }
        public SightViewModel(IStringLocalizer _localizer) : base(_localizer) { }

        [Required]
        [Display(Name = "You saw")]
        public string Name { get; set; }

        [Display(Name = "When you were in")]
        public string Location { get; set; }
    }
}