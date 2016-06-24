using System;
using TDiary.Model;

namespace TDiary.Providers.ViewModel.Model
{
    public class RecentExperienceViewModel
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Experience { get; set; }
        public string ExperienceType { get; set; }
        public int SavePosition { get; set; }
        public Rating Rating { get; set; }
        public string RatingDescription
        {
            get
            {
                switch (Rating)
                {
                    case Rating.Good:
                        return "Good Mushroom";
                    case Rating.Bad:
                        return "Bad Mushroom";
                }
                return "Zen Moment";
            }
        }
    }
}