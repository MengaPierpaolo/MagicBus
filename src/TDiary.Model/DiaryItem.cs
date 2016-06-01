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
        
        // TODO: Hide this from API user
        public int Id { get; set; }
        
        public DateTime Date { get; private set; }
        
        public abstract string Experience { get; }
    }
}