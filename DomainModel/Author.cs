using System;
using System.ComponentModel.DataAnnotations;

namespace DomainModel
{
    /// <summary>
    /// Author entity class
    /// </summary>
    public class Author
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The first name cannot be null.")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "The length must be between 5 and 100.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "The last name cannot be null.")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "The length must be between 5 and 100.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "The language cannot be null.")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "The length must be between 5 and 50.")]
        public string Language { get; set; }
        
        public DateTime DateOfBirth { get; set; }

        public DateTime DateOfDeath { get; set; }
    }
}
