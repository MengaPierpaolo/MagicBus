using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Localization;
using TDiary.Model;

namespace TDiary.Providers.ViewModel.Model
{
    public abstract class ActivityViewModel : PageViewModel
    {
        public int Id { get; set; }
        private DateTime _date = DateTime.UtcNow;
        private IStringLocalizer _localizer;

        public ActivityViewModel(IStringLocalizer _localizer)
        {
            this._localizer = _localizer;
        }

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

        public bool SavePressed
        {
            get
            {
                return SubmitButtonUsed == "Save it!";
            }
        }

        public int SavePosition { get; set; }

        [Display(Name = "What was your experience, dude?")]
        public Rating Rating { get; set; }

        public IDictionary<string, string> Ratings
        {
            get
            {
                return new Dictionary<string, string>
                {
                   {((int)Rating.Good).ToString(), _localizer.GetString(Rating.Good.ToString())},
                   {((int)Rating.Indifferent).ToString(), _localizer.GetString(Rating.Indifferent.ToString())},
                   {((int)Rating.Bad).ToString(), _localizer.GetString(Rating.Bad.ToString())}
                };
            }
        }
    }
}