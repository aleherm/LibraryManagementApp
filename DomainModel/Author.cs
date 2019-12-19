using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DomainModel
{
    /// <summary>
    /// Author entity class
    /// </summary>
    public class Author : IValidatableObject
    {
        public int Id { get; set; }

        [Required(ErrorMessage = ErrorMessages.FirstNameRequired)]
        [StringLength(50, ErrorMessage = ErrorMessages.FirstNameRangeLength, MinimumLength = 2)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = ErrorMessages.LastNameRequired)]
        [StringLength(50, ErrorMessage = ErrorMessages.FirstNameRangeLength, MinimumLength = 2)]
        public string LastName { get; set; }

        [Required(ErrorMessage = ErrorMessages.LanguageRequired)]
        [StringLength(50, ErrorMessage = ErrorMessages.LanguageRangeLength, MinimumLength = 2)]
        public string Language { get; set; }

        public DateTime DateOfBirth { get; set; }

        public DateTime DateOfDeath { get; set; }

        public Author() { }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            IList<string> dataMembers = new List<string>();

            if (DateOfBirth != null && DateOfBirth > DateTime.Now)
            {
                dataMembers.Add("DateOfBirth");
            }

            if (DateOfDeath != null && DateOfDeath > DateTime.Now)
            {
                dataMembers.Add("DateOfDeath");
            }

            yield return new ValidationResult(ErrorMessages.InvalidDate, dataMembers);
        }
    }
}
