using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CookesMafia.Models;

namespace CookesMafia.Context
{
    public class EntityContext:DbContext
    {
        public DbSet<Person> Persones { get; set; }
        public DbSet<Debit> Debites { get; set; }
        public EntityContext()
        {
            //Database.EnsureCreated();
            ChangeTracker.LazyLoadingEnabled = false;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-7RIO7LH;Database=CookeDB;Trusted_Connection=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }


        }
}
