using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using testsystem.Models;
using testsystem.Models.Entities;

namespace testsystem.context
{
    public class MyContext : DbContext
    {
          public MyContext(DbContextOptions<MyContext> options)
          : base(options)
          { }


        public DbSet<Candidat> Candidats { get; set; }
        public DbSet<Viewer> Viewers { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Rating> Ratings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Candidat>()
                .Property(model => model.Email)
                .IsRequired();

        }
    }
}
