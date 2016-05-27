using System;

namespace TDiary.Model
{
    public class Sight : DiaryItem
    {
        public Sight(){}
        
        public Sight(DateTime diaryDate) : base(diaryDate)
        {
        }

        public override string Activity
        {
            get
            {
                return string.Format("You saw {0}", Name);
            }
        }

        public string Name { get; set; }
    }
}