using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace _VideoRentalShop.Models
{
    public class RentalHeader
    {
        public int RentalHeaderId { get; set; }
        public int CustomerId { get; set; }
        public DateTime RentedDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public Customer? Customer { get; set; }
        public ICollection<RentalDetail> RentalDetails { get; set; } = new List<RentalDetail>();
    }
}
