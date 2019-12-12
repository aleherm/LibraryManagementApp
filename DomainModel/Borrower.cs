using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DomainModel
{
    public class Borrower
    {
        public int Id { get; set; }

        [Required(ErrorMessage = ErrorMessages.BorrowerFirstNameRequired)]
        [MaxLength(50, ErrorMessage = ErrorMessages.FirstNameMaxLength)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = ErrorMessages.BorrowerLastNameRequired)]
        [MaxLength(50, ErrorMessage = ErrorMessages.LastNameMaxLength)]
        public string LastName { get; set; }
        
        [Required(ErrorMessage = ErrorMessages.EmailRequired)]
        [MaxLength(50, ErrorMessage = ErrorMessages.EmailMaxLength)]
        public string Email { get; set; }

        public EGenderType Gender { get; set; }

        public DateTime DateOfBirth { get; set; }

        public Address Address { get; set; }
        
        [Required(ErrorMessage = ErrorMessages.LoanRequired)]
        public IList<Loan> Loans { get; set; }

        [Required(ErrorMessage = ErrorMessages.ReaderFlagRequired)]
        public int ReaderFlg { get; set; }

        [Required(ErrorMessage = ErrorMessages.LibrarianFlagRequired)]
        public int LibrarianFlg { get; set; }

        public Borrower()
        {
            Loans = new List<Loan>();
        }
    }
}
