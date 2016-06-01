using System.ComponentModel.DataAnnotations;

namespace TDiary.ViewModel
{
    public class ChowViewModel : Activity
    {
        [Required]
        [Display(Name = "You consumed")]
        public string Description { get; set; }
        
        [Display(Name = "When you were in")]
        public string Location { get; set; }
    }
}