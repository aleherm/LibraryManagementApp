using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DomainModel
{
    /// <summary>
    /// Loan entity class
    /// </summary>
    public class Loan
    {
        public int Id { get; set; }

        [Required(ErrorMessage = ErrorMessages.LoanDateRequired)]
        public DateTime LoanDate { get; set; }

        [Required(ErrorMessage = ErrorMessages.LoanDateRequired)]
        public DateTime DueDate { get; set; }

        public DateTime ReturnDate { get; set; }

        //[Required(ErrorMessage = "The borrower must pe provided")]
        //public Borrower Borrower { get; set; }

        [Required(ErrorMessage = "The borrowed books list should not be null")]
        public IList<Book> BorrowedBooks { get; set; }

        public Loan()
        {
            BorrowedBooks = new List<Book>();
        }
    }
}