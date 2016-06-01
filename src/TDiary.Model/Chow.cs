using System;

namespace TDiary.Model
{
    public class Chow : DiaryItem
    {
        internal Chow(){}
        
        public Chow(DateTime diaryDate, string productConsumed) : base(diaryDate) {
            Description = productConsumed;
        }

        public override string Experience
        {
            get
            {
                return string.Format("You consumed {0}", Description);
            }
        }

        public string Description { get; private set; }
    }
}