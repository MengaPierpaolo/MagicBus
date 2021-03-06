using System;

namespace MagicBus.Model {

    public class Trip : Experience
    {
        internal Trip(){}

        public Trip(DateTime diaryDate, string fromLocation, string toLocation, ModeOfTransport modeOfTransport) : base(diaryDate) {
            From = fromLocation;
            To = toLocation;
            By = modeOfTransport;
        }

        public string From { get; private set; }

        public string To { get; private set; }

        public ModeOfTransport By { get; private set; }

        public override string Commentary
        {
            get
            {
                return string.Format("You went from {0} to {1} by {2}", From, To, By.ToString().ToLower());
            }
        }

        public static Trip Create(int id)
        {
            return new Trip() { Id = id };
        }

        public static Trip Create(int id, DateTime diaryDate, string from, string to, ModeOfTransport by, int savePosition, Rating rating, Journey journey)
        {
            return new Trip(diaryDate, from, to, by) { Id = id, SavePosition = savePosition, Rating = rating, Journey = journey };
        }
    }
}