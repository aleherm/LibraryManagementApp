// <copyright file="Loan.cs" company="Transilvania University of Brasov">
// Copyright (c) Transilvania University of Brasov. Code by Alexandra Hermeneanu. All rights reserved.
// </copyright>

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
            BorrowedEditions = new List<Edition>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Loan"/> class.
        /// </summary>
        /// <param name="loanDate">The loan date.</param>
        /// <param name="dueDate">The due date.</param>
        /// <param name="returnDate">The return date.</param>
        /// <param name="borrowedEditions">The list of borrowed editions.</param>
        public Loan(DateTime loanDate, DateTime dueDate, DateTime returnDate, List<Edition> borrowedEditions)
        {
            LoanDate = loanDate;
            DueDate = dueDate;
            ReturnDate = returnDate;
            BorrowedEditions = borrowedEditions;
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
        /// Gets or sets the list of borrowed Editions.
        /// </summary>
        [Required(ErrorMessage = "The borrowed editions list should not be null")]
        public IList<Edition> BorrowedEditions { get; set; }
    }
}