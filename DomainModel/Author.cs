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

        [Required(ErrorMessage = ErrorMessages.AuthorFirstNameRequired)]
        [MaxLength(50, ErrorMessage = ErrorMessages.FirstNameMaxLength)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "The author's last name cannot be null.")]
        [MaxLength(50, ErrorMessage = "The author's last name must have less that 50 characters.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "The author's language cannot be null.")]
        [MaxLength(50, ErrorMessage = "The author's language must have less than 50 characters.")]
        public string Language { get; set; }
        
        public DateTime DateOfBirth { get; set; }

        public DateTime DateOfDeath { get; set; }

        public Author()
        {

        }
    }
}
