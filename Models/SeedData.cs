using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using Microsoft.Extensions.DependencyInjection;

namespace WebApplication1.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MvcWebContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MvcWebContext>>()))
            {
                if (context.Lesson.Any()) { return; }
                var classs = new Classs[]//if (!context.Classs.Any())
                {
                //context.Classs.AddRange(
                    new Classs {NameOfClass = "7a"},
                    new Classs {NameOfClass = "7b"},
                    new Classs {NameOfClass = "7c"},
                    new Classs {NameOfClass = "7d"}
                //);
                };
                foreach (Classs cl in classs) {
                    context.Classs.Add(cl);
                }
                context.SaveChanges();
                var mark = new Mark[]//if (!context.Mark.Any())
                {
                //    context.Mark.AddRange(
                    new Mark {MarkOfLesson = 2},
                    new Mark {MarkOfLesson = 3},
                    new Mark {MarkOfLesson = 4},
                    new Mark {MarkOfLesson = 5}
                //);
                };
                foreach (Mark m in mark) {
                    context.Mark.Add(m);
                }
                context.SaveChanges();
                var discipline = new Discipline[]//if (!context.Discipline.Any())
                {
                //    context.Discipline.AddRange(
                    new Discipline {NameOfDiscipline = "Math"},
                    new Discipline {NameOfDiscipline = "Chemistry"},
                    new Discipline {NameOfDiscipline = "Languages"},
                    new Discipline {NameOfDiscipline = "Physics"}
                //);
                };
                foreach (Discipline disc in discipline) {
                    context.Discipline.Add(disc);
                }
                context.SaveChanges();
                var users = new Users[]//if (!context.Users.Any())
                {
                //context.Users.AddRange(
                    new Users { Username = "Ivanov_1", Name = "Ivanov", Surname = "Ivan", Lastname = "Ivanovich" },
                    new Users { Username = "Petrov_1", Name = "Petrov", Surname = "Petr", Lastname = "Petrovich" },
                    new Users { Username = "Mihaylov_1", Name = "Mihaylov", Surname = "Mihayl", Lastname = "Mihaylovich" },
                    new Users { Username = "Nikolaev_1", Name = "Nikolaev", Surname = "Nikolay", Lastname = "Nikolaevich" }
                //);
                };
                foreach (Users u in users) {
                    context.Users.Add(u);                
                }
                context.SaveChanges();
                var lesson = new Lesson[]//if (!context.Lesson.Any())
                {
                //     context.Lesson.AddRange(
                    new Lesson { Classsesid = classs.Single(c => c.NameOfClass == "7a").id, Disciplinesid = discipline.Single(d => d.NameOfDiscipline == "Languages").id, Marksid = mark.Single(m => m.MarkOfLesson == 5).id, Userssid = users.Single(u => u.Username == "Petrov_1").id },
                    new Lesson { Classsesid = classs.Single(c => c.NameOfClass == "7b").id, Disciplinesid = discipline.Single(d => d.NameOfDiscipline == "Chemistry").id, Marksid = mark.Single(m => m.MarkOfLesson == 5).id, Userssid = users.Single(u => u.Username == "Mihaylov_1").id },
                    new Lesson { Classsesid = classs.Single(c => c.NameOfClass == "7c").id, Disciplinesid = discipline.Single(d => d.NameOfDiscipline == "Math").id, Marksid = mark.Single(m => m.MarkOfLesson == 5).id, Userssid = users.Single(u => u.Username == "Nikolaev_1").id },
                    new Lesson { Classsesid = classs.Single(c => c.NameOfClass == "7d").id, Disciplinesid = discipline.Single(d => d.NameOfDiscipline == "Physics").id, Marksid = mark.Single(m => m.MarkOfLesson == 5).id, Userssid = users.Single(u => u.Username == "Ivanov_1").id }
                    //); 
                };
                foreach (Lesson les in lesson) {
                    var lesDb = context.Lesson.Where(l =>
                        l.Marks.id == les.Marksid &&
                        l.Disciplines.id == les.Disciplinesid &&
                        l.Userss.id == les.Userssid &&
                        l.Classses.id == les.Classsesid).SingleOrDefault();
                    if (lesDb == null) { context.Lesson.Add(les); }
                }
                context.SaveChanges();
            }
        }
    }
}
