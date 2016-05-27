using System;

namespace TDiary.Model
{
    public abstract class DiaryItem
    {
        public DiaryItem() { }
        
        public DiaryItem(DateTime diaryDate)
        {
            Date = diaryDate;
        }
        
        public int Id { get; set; }
        
        public DateTime Date { get; private set; }
        
        public abstract string Activity { get; }
    }
}