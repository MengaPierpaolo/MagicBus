using System;

namespace TDiary.Model
{
    public abstract class DiaryItem
    {
        internal DiaryItem(){}

        public DiaryItem(DateTime diaryDate)
        {
            Date = diaryDate;
        }

        public int Id { get; internal set; }

        public DateTime Date { get; private set; }

        public int JourneyId { get; set; }

        public Journey Journey { get; set; }

        public int SavePosition { get; internal set; }

        public abstract string Experience { get; }

        public string ExperienceType
        {
            get
            {
                return GetType().Name;
            }
        }

        public void MovePositionTo(int position)
        {
            SavePosition = position;
        }

        public Rating Rating { get; set; }
    }
}