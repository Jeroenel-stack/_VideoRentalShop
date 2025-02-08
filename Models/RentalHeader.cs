using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace _VideoRentalShop.Models
{
    public class RentalHeader
    {

        [Key]
        public int Id { get; set; }
        public int CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public int MovieId { get; set; }
        [ForeignKey("MovieId")]

        public Movie? Movie { get; set; }
        public DateTime RentedDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public bool IsReturned { get; set; } = false;

        public Customer? Customer { get; set; }
        public ICollection<RentalDetail>? RentalDetails { get; set; }
    }
}
