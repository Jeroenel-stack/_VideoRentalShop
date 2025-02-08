using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using _VideoRentalShop.Models;

namespace _VideoRentalShop.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<_VideoRentalShop.Models.Customer> Customer { get; set; } = default!;
        public DbSet<_VideoRentalShop.Models.Movie> Movie { get; set; } = default!;
        public DbSet<_VideoRentalShop.Models.RentalHeader> RentalHeader { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Configure table names (optional)
            builder.Entity<Customer>().ToTable("Customer");
            builder.Entity<Movie>().ToTable("Movie");
            builder.Entity<RentalHeader>().ToTable("RentalHeader");
            builder.Entity<RentalDetail>().ToTable("RentalDetail");


            // Specify decimal precision for RentalPrice
            builder.Entity<Movie>()
                .Property(m => m.RentalPrice)
                .HasPrecision(10, 2); // 10 digits total, 2 decimal places

            builder.Entity<Movie>()
            .Property(m => m.RentalPrice)
             .HasColumnType("decimal(10,2)"); // ✅ Specify SQL column type

            // One Customer → Many Rentals
            builder.Entity<RentalHeader>()
                .HasOne(r => r.Customer)
                .WithMany(c => c.Rental)
                .HasForeignKey(r => r.CustomerId)
                .OnDelete(DeleteBehavior.Restrict); // ✅ Prevents cycles


            // One RentalHeader → Many RentalDetails
            builder.Entity<RentalDetail>()
                .HasOne(rd => rd.RentalHeader)
                .WithMany(r => r.RentalDetails)
                .HasForeignKey(rd => rd.RentalHeaderId)
            .OnDelete(DeleteBehavior.Restrict); // ✅ Prevents cascade issues

            // One Movie → Many RentalDetails
            builder.Entity<RentalDetail>()
                .HasOne(rd => rd.Movie)
                .WithMany(m => m.RentalDetails)
                .HasForeignKey(rd => rd.MovieId)
                 .OnDelete(DeleteBehavior.Restrict); // ✅ Prevents cycles
        }
    }
}

