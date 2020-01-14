// <copyright file="Borrower.cs" company="Transilvania University of Brasov">
// Copyright (c) Alexandra Hermeneanu. All rights reserved.
// </copyright>

namespace DomainModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// The Borrower entity.
    /// </summary>
    public class Borrower : IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Borrower"/> class.
        /// </summary>
        public Borrower()
        {
            Loans = new List<Loan>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Borrower"/> class.
        /// </summary>
        /// <param name="firstName">The first name.</param>
        /// <param name="lastName">The last name.</param>
        /// <param name="email">The email.</param>
        /// <param name="dateOfBirth">The date of birth.</param>
        /// <param name="address">The address.</param>
        /// <param name="readerFlg">The reader flag.</param>
        /// <param name="librarianFlg">The librarian flag.</param>
        public Borrower(string firstName, string lastName, string email, DateTime? dateOfBirth, Address address, bool readerFlg, bool librarianFlg)
        {
            Loans = new List<Loan>();
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            DateOfBirth = dateOfBirth;
            Address = address;
            ReaderFlg = readerFlg;
            LibrarianFlg = librarianFlg;
        }

        /// <summary>
        /// Gets or sets the ID of the Borrower.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        [Required(ErrorMessage = ErrorMessages.FirstNameRequired)]
        [StringLength(50, ErrorMessage = ErrorMessages.FirstNameRangeLength, MinimumLength = 2)]
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        [Required(ErrorMessage = ErrorMessages.LastNameRequired)]
        [StringLength(50, ErrorMessage = ErrorMessages.LastNameRangeLength, MinimumLength = 2)]
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        [Required(ErrorMessage = ErrorMessages.EmailRequired)]
        [EmailAddress(ErrorMessage = ErrorMessages.InvalidEmail)]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the gender.
        /// </summary>
        public EGenderType Gender { get; set; }

        /// <summary>
        /// Gets or sets the date of birth.
        /// </summary>
        public DateTime? DateOfBirth { get; set; }

        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        public Address Address { get; set; }

        /// <summary>
        /// Gets or sets the loan list.
        /// </summary>
        [Required(ErrorMessage = ErrorMessages.LoanRequired)]
        public IList<Loan> Loans { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the borrower is a reader as well or not.
        /// </summary>
        [Required(ErrorMessage = ErrorMessages.ReaderFlagRequired)]
        public bool ReaderFlg { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the borrower is a librarian as well or not.
        /// </summary>
        [Required(ErrorMessage = ErrorMessages.LibrarianFlagRequired)]
        public bool LibrarianFlg { get; set; }

        /// /// <summary>
        /// Validates the entity.
        /// </summary>
        /// <param name="validationContext">The validation context.</param>
        /// <returns>The validation result and member names.</returns>
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<string> memberNames = new List<string>();
            if (DateOfBirth != null && DateOfBirth > DateTime.Now)
            {
                memberNames.Add("DateOfBirth");
            }

            if (!(ReaderFlg || LibrarianFlg))
            {
                memberNames.Add("ReaderFlg");
                memberNames.Add("LibrarianFlg");
            }

            if (memberNames.Count != 0)
            {
                yield return new ValidationResult(ErrorMessages.InvalidData, memberNames);
            }

            yield return null;
        }

        /// <summary>
        /// Shows the data of the current entity.
        /// </summary>
        /// <returns>Output string for an Borrower entity.</returns>
        public override string ToString()
        {
            return $"{Id} | {FirstName} | {LastName} | {Email} | {DateOfBirth.Value.ToString("dd/MM/yyyy")} | {Address} ";
        }
    }
}
