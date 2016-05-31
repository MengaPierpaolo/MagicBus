using System;
using System.ComponentModel.DataAnnotations;

namespace TDiary.ViewModel
{
    public class Activity
    {
        private DateTime _date = DateTime.UtcNow;

        [Required]
        [DataType(DataType.Date)]
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
        
        public string SubmitButtonUsed { get; set; }
    }
}