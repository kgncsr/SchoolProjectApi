using Microsoft.EntityFrameworkCore;
using School.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace School.DataAccess.Concrete.EfCore
{
    public class SchoolContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=DESKTOP-5OA1FVG;Database=SchoolDbs;Trusted_Connection=True;MultipleActiveResultSets=true");
        }

        public DbSet<Student> Students { get; set; }
    }
}
