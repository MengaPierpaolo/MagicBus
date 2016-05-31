using System.ComponentModel.DataAnnotations;

namespace TDiary.ViewModel
{
    public class ChowViewModel : Activity
    {
        [Required]
        public string Description { get; set; }
    }
}