using System;
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

        public DateTime DueDate { get; set; }

        public DateTime ReturnDate { get; set; }

        [Required(ErrorMessage = "The name of the borrower must pe provided")]
        public Borrower Borrower { get; set; }
    }
}