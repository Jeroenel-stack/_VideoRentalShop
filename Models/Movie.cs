using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace _VideoRentalShop.Models
{
    public class Movie
    {
        
        public int MovieId { get; set; }
        public string? Title { get; set; }
        public string? Genre { get; set; }
        public int Stock { get; set; }  // Number of copies available
        public DateTime ReleaseDate { get; set; }
        public string? Director { get; set; }
        public string? Description { get; set; }

        [Column(TypeName = "decimal(10,2)")] //  Define precision here
        [Precision(10, 2)] //  Recommended for EF Core 6+
        public decimal RentalPrice { get; set; }

        public ICollection<RentalDetail>? RentalDetails { get; set; } // Navigation Property
    }
}
