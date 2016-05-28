using System;

namespace TDiary.ViewModel
{
    public class Activity 
    {
        public DateTime Date { get; set; } = DateTime.Now;
        
        public string Experience { get; internal set; }
        
        public string SubmitButtonUsed { get; set; }
    }
}