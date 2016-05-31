using System.ComponentModel.DataAnnotations;

namespace TDiary.ViewModel
{
    public class SightViewModel : Activity
    {
        [Required]
        public string Name { get; set; }
    }
}