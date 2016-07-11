using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Localization;

namespace TDiary.Providers.ViewModel.Model
{
    public class ChowViewModel : ActivityViewModel
    {
        internal ChowViewModel(IStringLocalizer _localizer) : base(_localizer) { }

        [Required]
        [Display(Name = "You consumed")]
        public string Description { get; set; }

        [Display(Name = "When you were in")]
        public string Location { get; set; }
    }
}