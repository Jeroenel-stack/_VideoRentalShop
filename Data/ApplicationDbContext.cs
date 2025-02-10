using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using _VideoRentalShop.Models;
using System.Reflection.Emit;
using Microsoft.AspNetCore.Identity;

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
        public DbSet<_VideoRentalShop.Models.RentalDetail> RentalHeaderDetails { get; set; } = default!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityUserLogin<string>>()
                .HasKey(l => new { l.LoginProvider, l.ProviderKey });



            modelBuilder.Entity<Movie>(entity =>
            {
                entity.HasKey(m => m.MovieId);
                entity.Property(m => m.Title)
                    .IsRequired()
                    .HasMaxLength(100);
                entity.Property(m => m.Genre)
                    .IsRequired()
                    .HasMaxLength(50);
                entity.Property(m => m.Director)
                    .IsRequired()
                    .HasMaxLength(100);
                entity.Property(m => m.RentalPrice)
                    .HasColumnType("decimal(10, 2)");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(c => c.CustomerId);
                entity.Property(c => c.LastName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .UseCollation("Latin1_General_CI_AS");
                entity.Property(c => c.FirstName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .UseCollation("Latin1_General_CI_AS");
                entity.HasIndex(c => c.Email)
                    .IsUnique();
                entity.Property(c => c.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(100);
                entity.Property(c => c.Address)
                    .IsRequired()
                    .HasMaxLength(255);
                entity.Property(c => c.MembershipDate)
                    .HasDefaultValueSql("GETDATE()");
            });

            modelBuilder.Entity<RentalHeader>(entity =>
            {
                entity.HasKey(rh => rh.RentalHeaderId);
                entity.HasOne(rh => rh.Customer)
                    .WithMany(c => c.RentalHeaders)
                    .HasForeignKey(rh => rh.CustomerId)
                    .OnDelete(DeleteBehavior.Cascade);
                entity.Property(rh => rh.RentedDate)
                   .HasDefaultValueSql("GETDATE()");
            });

            modelBuilder.Entity<RentalDetail>(entity =>
            {
                entity.HasKey(rd => rd.RentalDetailId);
                entity.Property(rd => rd.RentalDetailId)
                    .ValueGeneratedOnAdd();
                entity.HasOne(rd => rd.RentalHeader)
                    .WithMany(rh => rh.RentalDetails)
                    .HasForeignKey(rd => rd.RentalHeaderId)
                    .OnDelete(DeleteBehavior.Cascade);
                entity.HasOne(rd => rd.Movie)
                    .WithMany()
                    .HasForeignKey(rd => rd.MovieId)
                    .OnDelete(DeleteBehavior.Restrict);

            });
        }
    }
}


