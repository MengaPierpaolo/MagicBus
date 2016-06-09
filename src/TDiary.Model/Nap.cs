using System;

namespace TDiary.Model
{
    public class Nap : DiaryItem, ILocatable
    {
        internal Nap() { }

        public Nap(DateTime diaryDate, string description) : base(diaryDate)
        {
            Description = description;
        }

        public string Description { get; private set; }

        public override string Experience
        {
            get
            {
                var d = Description + (Location == string.Empty ? string.Empty : " in " + Location);
                return string.Format("You snoozed in {0}", d);
            }
        }

        public string Location { get; set; }

        public static Nap Create(int id)
        {
            return new Nap { Id = id };
        }

        public static Nap Create(int id, DateTime diaryDate, string description, string location, int savePosition)
        {
            return new Nap(diaryDate, description) { Id = id, Location = location, SavePosition = savePosition };
        }
    }
}