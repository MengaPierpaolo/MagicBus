using System.ComponentModel.DataAnnotations;

namespace TDiary.Providers.ViewModel.Model
{
    public class NapViewModel : ActivityViewModel
    {
        [Required]
        [Display(Name = "You snoozed in")]
        public string Description { get; set; }

        [Display(Name = "When you were in")]
        public string Location { get; set; }
    }
}