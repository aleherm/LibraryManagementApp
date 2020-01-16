// <copyright file="Edition.cs" company="Transilvania University of Brasov">
// Copyright (c) Alexandra Hermeneanu. All rights reserved.
// </copyright>

namespace DomainModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Edition entity class.
    /// </summary>
    public class Edition : IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Edition"/> class.
        /// </summary>
        public Edition()
        {
            Loans = new List<Loan>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Edition" /> class.
        /// </summary>
        /// <param name="publisher">The publisher name.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="year">The year.</param>
        /// <param name="bookType">The book type.</param>
        /// <param name="noForLibrary">The number of books for library reading.</param>
        /// <param name="noForLoan">The number of books for loan.</param>
        public Edition(string publisher, int pageNumber, int year, EBookType bookType, int noForLibrary, int noForLoan)
        {
            Publisher = publisher;
            PageNumber = pageNumber;
            Year = year;
            BookType = bookType;
            NoForLibrary = noForLibrary;
            NoForLoan = noForLoan;
            NoTotal = noForLoan + noForLibrary;
            Loans = new List<Loan>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Edition" /> class.
        /// </summary>
        /// <param name="publisher">The publisher name.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="year">The year.</param>
        /// <param name="bookType">The book type.</param>
        /// <param name="noForLibrary">The number of books for library reading.</param>
        /// <param name="noForLoan">The number of books for loan.</param>
        /// <param name="loans">The loan list.</param>
        public Edition(string publisher, int pageNumber, int year, EBookType bookType, int noForLibrary, int noForLoan, List<Loan> loans)
        {
            Publisher = publisher;
            PageNumber = pageNumber;
            Year = year;
            BookType = bookType;
            NoForLibrary = noForLibrary;
            NoForLoan = noForLoan;
            NoTotal = noForLoan + noForLibrary;
            Loans = loans;
        }

        /// <summary>
        /// Gets or sets the ID of the borrower.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the book type.
        /// </summary>
        public EBookType BookType { get; set; }

        /// <summary>
        /// Gets or sets the page number.
        /// </summary>
        [Range(5, 5000, ErrorMessage = ErrorMessages.PageNumberRange)]
        public int PageNumber { get; set; }

        /// <summary>
        /// Gets or sets the year.
        /// </summary>
        public int? Year { get; set; }

        /// <summary>
        /// Gets or sets the publisher name.
        /// </summary>
        [Required(ErrorMessage = ErrorMessages.PublisherRequired)]
        [StringLength(100, MinimumLength = 3, ErrorMessage = ErrorMessages.PublisherRangeLength)]
        public string Publisher { get; set; }

        /// <summary>
        /// Gets or sets the number of books for library reading.
        /// </summary>
        [Required(ErrorMessage = ErrorMessages.NoBooksForLibraryRequired)]
        [Range(0, 50, ErrorMessage = ErrorMessages.LibraryBooksRangeNumber)]
        public int NoForLibrary { get; set; }

        /// <summary>
        /// Gets or sets the number of books for loan.
        /// </summary>
        [Required(ErrorMessage = ErrorMessages.NoBooksForLoanRequired)]
        [Range(0, 50, ErrorMessage = ErrorMessages.LoanBooksRangeNumber)]
        public int NoForLoan { get; set; }

        /// <summary>
        /// Gets or sets the total number of books.
        /// </summary>
        [Required(ErrorMessage = ErrorMessages.NoTotalBooksRequired)]
        [Range(0, 100, ErrorMessage = ErrorMessages.TotalBooksRangeNumber)]
        public int NoTotal { get; set; }
        
        /// <summary>
        /// Gets or sets the list of loans.
        /// </summary>
        [Required(ErrorMessage = ErrorMessages.LoanRequired)]
        public IList<Loan> Loans { get; set; }

        /// <summary>
        /// Validates the entity.
        /// </summary>
        /// <param name="validationContext">The validation context.</param>
        /// <returns>The validation result and member names.</returns>
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<string> memberNames = new List<string>();
            if (Year.HasValue && (Year > DateTime.Now.Year || Year <= 0))
            {
                memberNames.Add("Year");
            }

            if (NoForLibrary > NoTotal || NoForLibrary < 0 || NoForLibrary > 50)
            {
                memberNames.Add("NoForLibrary");
            }

            if (NoForLoan > NoTotal || NoForLoan < 0 || NoForLoan > 50)
            {
                memberNames.Add("NoForLoan");
            }

            if (NoTotal < 0 || NoForLoan > 100)
            {
                memberNames.Add("NoTotal");
            }

            if (memberNames.Count != 0)
            {
                yield return new ValidationResult(ErrorMessages.InvalidNumber, memberNames);
            }

            if (Loans != null && Loans.Count == 0)
            {
                memberNames.Add("Loans");
            }

            yield return null;
        }

        /// <summary>
        /// Shows the data of the current entity.
        /// </summary>
        /// <returns>Output string for an Edition entity.</returns>
        public override string ToString()
        {
            return $"{Publisher} | year {Year} | {PageNumber} pages | {NoForLibrary} to library + {NoForLoan} to loan = {NoTotal} total ";
        }

        /// <summary>
        /// Determines whether the specified <see cref="System.Object" />, is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            Edition edition = obj as Edition;
            if (Id == edition.Id && 
                PageNumber == edition.PageNumber && 
                Publisher.Equals(edition.Publisher))
            {
                return true;
            }
            
            return false;
        }
    }
}
