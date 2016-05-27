using System;
using TDiary.Model.Interface;

namespace TDiary.Model
{
    public abstract class DiaryItem : IExperienceable
    {
        public DiaryItem(){}
        
        public DiaryItem(DateTime diaryDate)
        {
            Date = diaryDate;
        }
        
        public int Id { get; set; }
        
        public DateTime Date { get; private set; }
        
        public abstract string Activity { get; }
    }
}