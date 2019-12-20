using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DomainModel
{
    /// <summary>
    /// Edition entity class
    /// </summary>
    public class Edition : IValidatableObject
    {
        public int Id { get; set; }

        public EBookType BookType { get; set; }

        [Range(5, 5000, ErrorMessage = ErrorMessages.PageNumberRange)]
        public int PageNumber { get; set; }

        public int? Year { get; set; }
        
        [Required(ErrorMessage = ErrorMessages.PublisherRequired)]
        [StringLength(100, MinimumLength = 3, ErrorMessage = ErrorMessages.PublisherRangeLength)]
        public string Publisher { get; set; }

        [Required(ErrorMessage = ErrorMessages.NoBooksForLibraryRequired)]
        [Range(0, 50, ErrorMessage = ErrorMessages.LibraryBooksRangeNumber)]
        public int NoForLibrary { get; set; }

        [Required(ErrorMessage = ErrorMessages.NoBooksForLoanRequired)]
        [Range(0, 50, ErrorMessage = ErrorMessages.LoanBooksRangeNumber)]
        public int NoForLoan { get; set; }

        [Required(ErrorMessage = ErrorMessages.NoTotalBooksRequired)]
        [Range(0, 100, ErrorMessage = ErrorMessages.TotalBooksRangeNumber)]
        public int NoTotal { get; set; }

        public Edition() { }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<string> memberNames = new List<string>();
            if(Year.HasValue && (Year > DateTime.Now.Year || Year <= 0))
            {
                memberNames.Add("Year");
            }

            if(NoForLoan > NoTotal)
            {
                memberNames.Add("NoForLoan");
            }

            if (NoForLibrary > NoTotal)
            {
                memberNames.Add("NoForLibrary");
            }
            
            if (memberNames.Count != 0)
                yield return new ValidationResult(ErrorMessages.InvalidYear, memberNames);
            yield return null;
        }
    }
}
