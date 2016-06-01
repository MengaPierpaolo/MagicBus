using System;

namespace TDiary.Model {
    
    public class Trip : DiaryItem 
    {
        internal Trip(){}
        
        public Trip(DateTime diaryDate, string fromLocation, string toLocation, ModeOfTransport modeOfTransport) : base(diaryDate) {
            From = fromLocation;
            To = toLocation;
            By = modeOfTransport;
        }

        public string From { get; private set; }
        
        public string To { get; private set; }
        
        public ModeOfTransport By { get; private set; }

        public override string Experience
        {
            get
            {
                return string.Format("You went from {0} to {1} by {2}", From, To, By.ToString().ToLower());
            }
        }
    }
}