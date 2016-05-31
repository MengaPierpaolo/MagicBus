using System;

namespace TDiary.Model {
    
    public class Trip : DiaryItem 
    {
        internal Trip(){}
        
        public Trip(DateTime diaryDate, string fromLocation, string toLocation, string modeOfTransport) : base(diaryDate) {
            From = fromLocation;
            To = toLocation;
            By = modeOfTransport;
        }

        public override string Experience
        {
            get
            {
                return string.Format("You went from {0} to {1} by {2}", From, To, By);
            }
        }

        public string From { get; private set; }
        
        public string To { get; private set; }
        
        public string By { get; private set; }
    }
}