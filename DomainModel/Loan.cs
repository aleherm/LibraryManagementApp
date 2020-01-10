namespace DomainModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Loan entity class.
    /// </summary>
    [SuppressMessage("Microsoft.StyleCop.CSharp.OrderingRules", "SA1101", Justification = "In .NET this is rarely used.")]
    public class Loan
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Loan"/> class.
        /// </summary>
        public Loan()
        {
            BorrowedBooks = new List<Book>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Loan"/> class.
        /// </summary>
        /// <param name="loanDate">The loan date.</param>
        /// <param name="dueDate">The due date.</param>
        /// <param name="returnDate">The return date.</param>
        /// <param name="borrowedBooks">The list of borrowed books.</param>
        public Loan(DateTime loanDate, DateTime dueDate, DateTime returnDate, List<Book> borrowedBooks)
        {
            LoanDate = loanDate;
            DueDate = dueDate;
            ReturnDate = returnDate;
            BorrowedBooks = borrowedBooks;
        }

        /// <summary>
        /// Gets or sets the ID of the loan.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the loan date.
        /// </summary>
        [Required(ErrorMessage = ErrorMessages.LoanDateRequired)]
        public DateTime LoanDate { get; set; }

        /// <summary>
        /// Gets or sets the due date.
        /// </summary>
        [Required(ErrorMessage = ErrorMessages.LoanDateRequired)]
        public DateTime DueDate { get; set; }

        /// <summary>
        /// Gets or sets the return date.
        /// </summary>
        public DateTime ReturnDate { get; set; }

        /// <summary>
        /// Gets or sets the list of borrowed books. 
        /// </summary>
        [Required(ErrorMessage = "The borrowed books list should not be null")]
        public IList<Book> BorrowedBooks { get; set; }
    }
}