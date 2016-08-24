using System.Collections.Generic;

namespace TDiary.Model
{
    public class Journey
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Experience> Experiences { get; set; }
    }
}