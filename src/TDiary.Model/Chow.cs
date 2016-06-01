using System;

namespace TDiary.Model
{
    public class Chow : DiaryItem, ILocatable
    {
        internal Chow() { }

        public Chow(DateTime diaryDate, string productConsumed) : base(diaryDate)
        {
            Description = productConsumed;
        }

        public string Description { get; private set; }

        public override string Experience
        {
            get
            {
                var d = Description + (Location == string.Empty ? string.Empty : " in " + Location);
                return string.Format("You consumed {0}", d);
            }
        }

        public string Location { get; set; }
    }
}