using System.ComponentModel.DataAnnotations;

namespace TDiary.ViewModel
{
    public class SightViewModel : Activity
    {
        [Required]
        [Display(Name = "Sight Name")]
        public string Name { get; set; }
    }
}