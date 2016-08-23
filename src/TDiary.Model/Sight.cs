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

        public static Sight Create(int id)
        {
            return new Sight() { Id = id };
        }

        public static Sight Create(int id, DateTime diaryDate, string name, string location, int savePosition, Rating rating, Journey journey)
        {
            return new Sight(diaryDate, name) { Id = id, Location = location, SavePosition = savePosition, Rating = rating, Journey = journey };
        }
    }
}