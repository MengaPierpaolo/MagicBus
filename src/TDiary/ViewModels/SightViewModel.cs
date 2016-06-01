using System.ComponentModel.DataAnnotations;

namespace TDiary.ViewModel
{
    public class SightViewModel : Activity
    {
        [Required]
        [Display(Name = "You saw")]
        public string Name { get; set; }
        
        [Display(Name = "When you were in")]
        public string Location { get; set; }
    }
}