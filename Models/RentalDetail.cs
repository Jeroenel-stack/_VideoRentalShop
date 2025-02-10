using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace _VideoRentalShop.Models
{
    public class RentalDetail
    {
        public int RentalDetailId { get; set; }
        public int RentalHeaderId { get; set; }  
        public int MovieId { get; set; }
        public DateTime DueDate { get; set; }
        public int Quantity { get; set; }
        public string? Status { get; set; } 

        public RentalHeader? RentalHeader { get; set; }
        public Movie? Movie { get; set; }
    }
}
