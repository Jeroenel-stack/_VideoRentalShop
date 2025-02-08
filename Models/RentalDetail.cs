using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace _VideoRentalShop.Models
{
    public class RentalDetail
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("RentalHeaderId")]
        public int RentalHeaderId { get; set; }
        public RentalHeader? RentalHeader { get; set; }
        public int MovieId { get; set; }
        [ForeignKey("MovieId")]
        public DateTime DueDate { get; set; }
        public Movie? Movie { get; set; }

        public bool IsReturned { get; set; } = false;
    }
}
