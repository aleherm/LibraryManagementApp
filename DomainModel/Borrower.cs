using System.ComponentModel.DataAnnotations;

namespace DomainModel
{
    public class Borrower
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The first name cannot be null.")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "The length must be between 2 and 100.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "The last name cannot be null.")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "The length must be between 2 and 100.")]
        public string LastName { get; set; }


    }
}
