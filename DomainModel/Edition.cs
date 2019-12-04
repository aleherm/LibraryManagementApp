using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DomainModel
{
    /// <summary>
    /// Edition entity class
    /// </summary>
    public class Edition
    {
        [Range(0, 5000, ErrorMessage = "The page number must be between 0 an 5000.")]
        public int PageNumber { get; set; }

        [RangeValidator(1930, RangeBoundaryType.Inclusive, 2019, RangeBoundaryType.Inclusive)]
        public int Year { get; set; }

        public EBookType BookType { get; set; }

        [Required(ErrorMessage = "The Publisher name must be provided")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "The Publisher name must be between 5 and 50 characters")]
        public string Publisher { get; set; }

        [Required(ErrorMessage = "The number of books available for library reading must be provided")]
        public int NoForLibrary { get; set; }

        [Required(ErrorMessage = "The number of books available for loan purposes must be provided")]
        public int NoForLoan { get; set; }

        [Required(ErrorMessage = "The total number of books must be provided")]
        public int NoTotal { get; set; }

        [Required(ErrorMessage = "The borrower's email must be provided")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "The email must be between 5 and 50 characters")]
        public string Email { get; set; }

        public EGenderType Gender { get; set; }
        
        public DateTime DateOfBirth { get; set; }

        public Address Address { get; set; }

        [NotNullValidator(ErrorMessage = "Loan list must not be null")]
        public IList<Loan> Loans { get; set; }

        public int ReaderFlg { get; set; }
        public int LibrarianFlg { get; set; }
    }
}
