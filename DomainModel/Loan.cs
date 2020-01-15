// <copyright file="Loan.cs" company="Transilvania University of Brasov">
// Copyright (c) Alexandra Hermeneanu. All rights reserved.
// </copyright>

namespace DomainModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Loan entity class.
    /// </summary>
    public class Loan : IValidatableObject
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
        public DateTime? LoanDate { get; set; }

        /// <summary>
        /// Gets or sets the due date.
        /// </summary>
        [Required(ErrorMessage = ErrorMessages.LoanDateRequired)]
        public DateTime? DueDate { get; set; }

        /// <summary>
        /// Gets or sets the return date.
        /// </summary>
        public DateTime? ReturnDate { get; set; }

        /// <summary>
        /// Gets or sets the list of borrowed Editions.
        /// </summary>
        [Required(ErrorMessage = "The borrowed editions list should not be null")]
        public IList<Edition> BorrowedEditions { get; set; }

        /// <summary>
        /// Validates the entity.
        /// </summary>
        /// <param name="validationContext">The validation context.</param>
        /// <returns>The validation result and member names.</returns>
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            IList<string> dataMembers = new List<string>();

            if (LoanDate != null && DueDate != null && LoanDate > DueDate)
            {
                dataMembers.Add("LoanDate");
                dataMembers.Add("DueDate");
            }

            if (LoanDate != null && ReturnDate != null && LoanDate > ReturnDate)
            {
                if (dataMembers.IndexOf("LoanDate") != 0)
                {
                    dataMembers.Add("LoanDate");
                }

                dataMembers.Add("ReturnDate");
            }

            if (LoanDate != null && LoanDate > DateTime.Now)
            {
                if (dataMembers.IndexOf("LoanDate") != 0)
                {
                    dataMembers.Add("LoanDate");
                }
            }

            if (DueDate != null && DueDate > DateTime.Now)
            {
                if (dataMembers.IndexOf("DueDate") != 0)
                {
                    dataMembers.Add("DueDate");
                }
            }

            if (ReturnDate != null && ReturnDate > DateTime.Now)
            {
                if (dataMembers.IndexOf("ReturnDate") != 0)
                {
                    dataMembers.Add("ReturnDate");
                }
            }

            if (dataMembers.Count != 0)
            {
                yield return new ValidationResult(ErrorMessages.InvalidDate, dataMembers);
            }

            yield return null;
        }

        /// <summary>
        /// Shows the data of the current entity.
        /// </summary>
        /// <returns>Output string for an Author entity.</returns>
        public override string ToString()
        {
            return $"loan: {LoanDate.Value.Date} | due: {DueDate.Value.Date} | return: {ReturnDate.Value.Date} ";
        }
    }
}