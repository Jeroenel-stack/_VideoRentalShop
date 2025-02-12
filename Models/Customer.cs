using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _VideoRentalShop.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
        public string? Sex { get; set; }
        [NotMapped]
        public int Age => DateTime.Now.Year - DateOfBirth.Year;
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime MembershipDate { get; set; }

        public ICollection<RentalHeader>? RentalHeaders { get; set; } // Navigation Property


    }
}
