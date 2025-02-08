using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _VideoRentalShop.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? Sex { get; set; }
        [NotMapped] //  Prevents EF from creating a database column
        public int Age => DateTime.Now.Year - DateOfBirth.Year;
        public string? Email { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }

        public ICollection<RentalHeader>? Rental { get; set; } // Navigation Property


    }
}
