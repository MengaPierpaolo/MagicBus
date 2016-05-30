using System;
using System.ComponentModel.DataAnnotations;
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
        
        // [Key]
        public int Id { get; set; }
        
        // [Required]
        // [DataType(DataType.Date)]
        public DateTime Date { get; private set; }
        
        public abstract string Activity { get; }
    }
}