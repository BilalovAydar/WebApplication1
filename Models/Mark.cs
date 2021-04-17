using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Mark
    {
        public int id { get; set; }
        public int MarkOfLesson { get; set; }
        public ICollection<Lesson> Lessons { get; set; }
    }
}
