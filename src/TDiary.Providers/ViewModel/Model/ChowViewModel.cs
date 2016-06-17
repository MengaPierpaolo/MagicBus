using System.ComponentModel.DataAnnotations;

namespace TDiary.Providers.ViewModel.Model
{
    public class ChowViewModel : ActivityViewModel
    {
        [Required]
        [Display(Name = "You consumed")]
        public string Description { get; set; }

        [Display(Name = "When you were in")]
        public string Location { get; set; }
    }
}