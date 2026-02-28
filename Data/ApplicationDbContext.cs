using BikeRentProjects.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace BikeRentProjects.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<RentalRequest>()
                        .HasOne(r => r.Bike)
                        .WithMany(b => b.RentalRequests)
                        .HasForeignKey(r => r.BikeID)
                        .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<RentalRequest>()
                        .HasOne(r => r.User)
                        .WithMany(u => u.RentalRequests)
                        .HasForeignKey(r => r.UserID)
                        .OnDelete(DeleteBehavior.Cascade);

        }


        public DbSet<Bike> Bike { get; set; } = default!;
        public DbSet<RentalRequest> RentalRequest { get; set; } = default!;
        public DbSet<TypeOfBike> TypeOfBike { get; set; } = default!;


    }
}
