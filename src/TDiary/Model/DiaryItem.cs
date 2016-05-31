using System;
using System.ComponentModel.DataAnnotations;
using TDiary.Model.Interface;

namespace TDiary.Model
{
    public abstract class DiaryItem : IExperienceable
    {
        internal DiaryItem(){}
        
        public DiaryItem(DateTime diaryDate)
        {
            Date = diaryDate;
        }
        
        public int Id { get; set; }
        
        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; private set; }
        
        public abstract string Experience { get; }
    }
}