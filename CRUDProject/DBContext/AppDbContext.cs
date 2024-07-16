using CRUDProject.Data;
using Microsoft.EntityFrameworkCore;
using System;

namespace CRUDProject.DBContext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Rental> Rentals { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Rental>(entity =>
            {
                entity.HasKey(r => r.rental_id);
                entity.ToTable("rental_analytics"); 
            });

            base.OnModelCreating(modelBuilder);
        }



    }

}
