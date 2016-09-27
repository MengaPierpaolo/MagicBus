using System;

namespace MagicBus.Model
{
    public class Nap : Experience, ILocatable
    {
        internal Nap() { }

        public Nap(DateTime diaryDate, string description) : base(diaryDate)
        {
            Description = description;
        }

        public string Description { get; private set; }

        public override string Commentary
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

        public static Nap Create(int id, DateTime diaryDate, string description, string location, int savePosition, Rating rating, Journey journey)
        {
            return new Nap(diaryDate, description) { Id = id, Location = location, SavePosition = savePosition, Rating = rating, Journey = journey };
        }
    }
}