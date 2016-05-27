using System;

namespace TDiary.Model {
    
    public class Trip : DiaryItem 
    {
        public Trip(){}
        
        public Trip(DateTime diaryDate) : base(diaryDate) {}

        public override string Activity
        {
            get
            {
                return string.Format("You went from {0} to {1}", From, To);
            }
        }

        public string From { get; set; }
        
        public string To { get; set; }
        
        public string By { get; set; }
    }
}