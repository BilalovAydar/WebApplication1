﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Classs
    {
        public int id { get; set; }
        public string NameOfClass { get; set; }
        public ICollection<Lesson> Lessons { get; set; }
    }
}
