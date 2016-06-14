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

        public int SavePosition { get; internal set; }

        public abstract string Experience { get; }

        public string ExperienceType
        {
            get
            {
                return this.GetType().Name;
            }
        }

        public void MovePositionTo(int position)
        {
            this.SavePosition = position;
        }
    }
}