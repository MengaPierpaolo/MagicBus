using System.ComponentModel.DataAnnotations;

namespace TDiary.ViewModel
{
    public class ChowViewModel : Activity
    {
        [Required]
        [Display(Name = "Chow Description")]
        public string Description { get; set; }
    }
}