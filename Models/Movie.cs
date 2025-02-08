using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace _VideoRentalShop.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }

        public string? Title { get; set; }

        public string? Genre { get; set; }

        public int Stock { get; set; } // Available copies
        public DateTime ReleaseDate { get; set; }

        [Column(TypeName = "decimal(10,2)")] // ✅ Define precision here
        [Precision(10, 2)] // ✅ Recommended for EF Core 6+
        public decimal RentalPrice { get; set; }
     

        public ICollection<RentalDetail>? RentalDetails { get; set; } // Navigation Property
    }
}
