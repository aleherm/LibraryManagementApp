using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DomainModel
{
    public class Borrower
    {
        public int Id { get; set; }

        [Required(ErrorMessage = ErrorMessages.FirstNameRequired)]
        [StringLength(50, ErrorMessage = ErrorMessages.FirstNameRangeLength, MinimumLength = 2)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = ErrorMessages.LastNameRequired)]
        [StringLength(50, ErrorMessage = ErrorMessages.FirstNameRangeLength, MinimumLength = 2)]
        public string LastName { get; set; }
        
        [Required(ErrorMessage = ErrorMessages.EmailRequired)]
        [EmailAddress(ErrorMessage = ErrorMessages.InvalidEmail)]
        public string Email { get; set; }

        public EGenderType Gender { get; set; }

        public DateTime DateOfBirth { get; set; }

        public Address Address { get; set; }
        
        [Required(ErrorMessage = ErrorMessages.LoanRequired)]
        public IList<Loan> Loans { get; set; }

        [Required(ErrorMessage = ErrorMessages.ReaderFlagRequired)]
        public bool ReaderFlg { get; set; }

        [Required(ErrorMessage = ErrorMessages.LibrarianFlagRequired)]
        public bool LibrarianFlg { get; set; }

        public Borrower()
        {
            Loans = new List<Loan>();
        }
    }
}
