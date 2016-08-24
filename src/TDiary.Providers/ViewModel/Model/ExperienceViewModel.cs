using System;
using System.Globalization;
using Microsoft.Extensions.Localization;
using TDiary.Model;

namespace TDiary.Providers.ViewModel.Model
{
    public class ExperienceViewModel
    {
        private IStringLocalizer _localizer;

        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Commentary { get; set; }

        public string FullExperience
        {
            get
            {
                return string.Format("On {0}, y{1}, and it was a {2} experience",
                    Date.ToString("d MMMM", CultureInfo.CurrentUICulture),
                    Commentary.Substring(1),
                    RatingDescription.ToLower());
            }
        }

        public string ExperienceType { get; set; }
        public int SavePosition { get; set; }
        public Rating Rating { get; set; }

        public string RatingDescription
        {
            get
            {
                return _localizer.GetString(Rating.ToString());
            }
        }

        internal void Localize(IStringLocalizer localizer)
        {
            _localizer = localizer;
        }

        public bool IsFirstOfTheDay { get; internal set; }

        public bool IsLastOfTheDay { get; internal set; }
    }
}