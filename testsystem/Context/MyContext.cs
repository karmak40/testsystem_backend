using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using testsystem.models;

namespace testsystem.context
{
    class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options)
        : base(options)
        { }

        public DbSet<Candidat> Candidats { get; set; }
        public DbSet<Viewer> Viewers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Candidat>()
                .Property(model => model.Email)
                .IsRequired();

            modelBuilder.Entity<Candidat>().Property(model => model.Name).IsRequired();
        }
    }
}
