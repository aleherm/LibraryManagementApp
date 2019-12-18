using System.ComponentModel.DataAnnotations;

namespace DomainModel
{
    public class Address
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The Borrower's city name cannot be null.")]
        [MaxLength(20)]
        public string City { get; set; }
        
        [MaxLength(50)]
        public string Street { get; set; }
        
        public int Number { get; set; }
    }
}