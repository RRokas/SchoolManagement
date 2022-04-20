using Microsoft.EntityFrameworkCore;
using SchoolManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement
{
    internal class SchoolDb : DbContext
    {
        public DbSet<Department> Departments { get; set; }
        public DbSet<Lecture> Lectures { get; set; }
        public DbSet<Student> Students { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer(@"Server=localhost;Database=School;Trusted_Connection=True;");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Department>()
                .HasMany(p => p.Lectures);
        }
    }
}
