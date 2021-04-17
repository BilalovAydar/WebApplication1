using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Lesson
    {
        public int id { get; set; }
        public int Userssid { get; set; }
        public int Marksid { get; set; }
        public int Disciplinesid { get; set; }
        public int Classsesid { get; set; }
        public Users Userss { get; set; }
        public Mark Marks { get; set; }
        public Discipline Disciplines { get; set; }
        public Classs Classses { get; set; }
       
    }
}
