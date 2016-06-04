using System;
using System.ComponentModel.DataAnnotations;

namespace TDiary.ViewModel
{
    public abstract class ActivityViewModel : PageViewModel
    {
        public int Id { get; set; }
        private DateTime _date = DateTime.UtcNow;

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "On")]
        public DateTime Date
        {
            get
            {
                return _date;
            }
            set
            {
                _date = value;
            }
        }

        public string Experience { get; set; }

        public string ExperienceType
        {
            get
            {
                var t = this.GetType().Name; 
                return t.Substring(0, t.IndexOf("ViewModel"));
            }
        }

        public string SubmitButtonUsed { get; set; }
        
        public bool SavePressed
        {
            get
            {
                return this.SubmitButtonUsed == "Save it!";
            }
        }
    }
}