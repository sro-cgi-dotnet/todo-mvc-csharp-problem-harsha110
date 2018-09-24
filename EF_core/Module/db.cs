using harsha;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
namespace data_name
{
    public class SchoolContext : DbContext
    {

        public DbSet<Student> Students { get; set; }
        public DbSet<Labels> L1 { get; set; }
        public DbSet<Checklist> Ch1 { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        { 
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=noted1;Trusted_Connection=True;");
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.Entity<Student>().HasMany(n => n.Many_values_ch).WithOne().HasForeignKey(c => c.NoteId);
             modelBuilder.Entity<Student>().HasMany(n => n.Many_values).WithOne().HasForeignKey(c => c.NoteId);
        }

        public List<Student> retrive()
        {
            SchoolContext p = new SchoolContext();
          List<Student> opp = p.Students.ToList();
          return opp;
        }

    }
}