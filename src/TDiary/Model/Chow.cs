using System;

namespace TDiary.Model
{
    public class Chow : DiaryItem
    {
        public Chow() {}
        
        public Chow(DateTime diaryDate) : base(diaryDate) {}

        public override string Activity
        {
            get
            {
                return string.Format("You consumed {0}", Description);
            }
        }

        public string Description { get; set; }
    }
}