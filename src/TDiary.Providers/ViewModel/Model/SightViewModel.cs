using System.ComponentModel.DataAnnotations;

namespace TDiary.Providers.ViewModel.Model
{
    public class SightViewModel : ActivityViewModel
    {
        [Required]
        [Display(Name = "You saw")]
        public string Name { get; set; }

        [Display(Name = "When you were in")]
        public string Location { get; set; }
    }
}