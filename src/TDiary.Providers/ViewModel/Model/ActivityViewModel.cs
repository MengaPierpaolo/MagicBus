using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TDiary.Model;

namespace TDiary.Providers.ViewModel.Model
{
    public abstract class ActivityViewModel : PageViewModel
    {
        private DateTime _date = DateTime.UtcNow;
        protected internal IStringLocalizer _localizer;

        internal ActivityViewModel() { }
        public ActivityViewModel(IStringLocalizer localizer)
        {
            _localizer = localizer;
        }

        public int Id { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "On")]
        public DateTime Date
        {
            get
            {
                return _date;
            }
            set
            {
                _date = value;
            }
        }

        public string Experience { get; set; }

        public string ExperienceType { get; set; }

        public string SubmitButtonUsed { get; set; }

        public int SavePosition { get; set; }

        [Display(Name = "What was your experience, dude?")]
        public Rating Rating { get; set; }

        public IDictionary<string, string> Ratings
        {
            get
            {
                return new Dictionary<string, string>
                {
                   {((int)Rating.Good).ToString(), _localizer?.GetString(Rating.Good.ToString())},
                   {((int)Rating.Indifferent).ToString(), _localizer?.GetString(Rating.Indifferent.ToString())},
                   {((int)Rating.Bad).ToString(), _localizer?.GetString(Rating.Bad.ToString())}
                };
            }
        }

        public bool SavePressed
        {
            get
            {
                return SubmitButtonUsed == "Save it!";
            }
        }

        internal void Localize(IStringLocalizer localizer)
        {
            _localizer = localizer;
        }
    }
}