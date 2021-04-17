using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;



namespace WebApplication1.Data
{
    public class MvcWebContext : DbContext
    {
        public MvcWebContext(DbContextOptions<MvcWebContext> options)
            : base(options)
        {
        }
                
        public DbSet<WebApplication1.Models.Classs> Classs { get; set; }
        
        public DbSet<WebApplication1.Models.Discipline> Discipline { get; set; }

        public DbSet<WebApplication1.Models.Lesson> Lesson { get; set; }

        public DbSet<WebApplication1.Models.Mark> Mark { get; set; }

        public DbSet<WebApplication1.Models.Users> Users { get; set; }

        public DbSet<WebApplication1.Models.Person> Person { get; set; }
       /* protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Lesson>()
                ;
        }*/
    }
}
