using System;

namespace TDiary.Model
{
    public class Sight : DiaryItem, ILocatable
    {
        internal Sight() { }

        public Sight(DateTime diaryDate, string name) : base(diaryDate)
        {
            Name = name;
        }

        public string Name { get; private set; }

        public override string Experience
        {
            get
            {
                var n = Name + (Location == string.Empty ? string.Empty : " in " + Location);
                return string.Format("You saw {0}", n);
            }
        }

        public string Location { get; set; }
    }
}