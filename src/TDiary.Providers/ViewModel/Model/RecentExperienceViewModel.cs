using System;

namespace TDiary.Providers.ViewModel.Model
{
    public class RecentExperienceViewModel
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Experience { get; set; }
        public string ExperienceType { get; set; }
        public int SavePosition { get; set; }
    }
}