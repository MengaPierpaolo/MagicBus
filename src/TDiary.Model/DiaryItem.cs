using System;

namespace TDiary.Model
{
    public abstract class DiaryItem : IDiaryItem
    {
        internal DiaryItem(){}
        
        public DiaryItem(DateTime diaryDate)
        {
            Date = diaryDate;
        }
        
        public int Id { get; internal set; }
        
        public DateTime Date { get; private set; }
        
        public abstract string Experience { get; }
    }
    
    public interface IDiaryItem
    {
        
    }
}