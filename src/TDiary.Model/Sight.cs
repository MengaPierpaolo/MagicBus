using System;

namespace TDiary.Model
{
    public class Sight : DiaryItem
    {
        internal Sight() {}
        
        public Sight(DateTime diaryDate, string name) : base(diaryDate)
        {
            Name = name;
        }

        public string Name { get; private set; }

        public override string Experience
        {
            get
            {
                return string.Format("You saw {0}", Name);
            }
        }
    }
}