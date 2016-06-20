namespace TDiary.Providers.ViewModel.Model
{
    public static class ViewModelTitleExtensions
    {
        public static NapViewModel WithAddTitles(this NapViewModel item)
        {
            item.Title = "Naptastic!";
            item.Heading = "Where did you nod off?";
            return item;
        }

        public static NapViewModel WithEditTitles(this NapViewModel item)
        {
            item.Title = "Woken early?";
            item.Heading = "Adjust your sleep details.";
            return item;
        }

        public static SightViewModel WithAddTitles(this SightViewModel item)
        {
            item.Title = "What a sight!";
            item.Heading = "Seen something funky?";
            return item;
        }

        public static SightViewModel WithEditTitles(this SightViewModel item)
        {
            item.Title = "Double Take?";
            item.Heading = "Change what you saw.";
            return item;
        }

        public static ChowViewModel WithAddTitles(this ChowViewModel item)
        {
            item.Title = "Had some Chow?";
            item.Heading = "Yum, add it to the list!";
            return item;
        }

        public static ChowViewModel WithEditTitles(this ChowViewModel item)
        {
            item.Title = "Chow mixed up?";
            item.Heading = "Edit the details then.";
            return item;
        }

        public static TripViewModel WithAddTitles(this TripViewModel item)
        {
            item.Title = "Life is a Journey!";
            item.Heading = "Add your travel detail.";
            return item;
        }

        public static TripViewModel WithEditTitles(this TripViewModel item)
        {
            item.Title = "Lost?";
            item.Heading = "Edit your travel Detail.";
            return item;
        }
    }
}