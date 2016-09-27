using System;

namespace TDiary.Model
{
    public abstract class Experience
    {
        internal Experience(){}

        public Experience(DateTime diaryDate)
        {
            Date = diaryDate;
        }

        public int Id { get; internal set; }

        public DateTime Date { get; private set; }

        public Journey Journey { get; set; }

        public int SavePosition { get; internal set; }

        public abstract string Commentary { get; }

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