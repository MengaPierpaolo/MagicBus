using System;

namespace TDiary.Model
{
    public class Chow : DiaryItem, ILocatable, IDiaryItem
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

        public static Chow Create(int id)
        {
            return new Chow() { Id = id };
        }

        public static Chow Create(int id, DateTime diaryDate, string productConsumed, string location)
        {
            return new Chow(diaryDate, productConsumed) { Id = id, Location = location };
        }
    }
}