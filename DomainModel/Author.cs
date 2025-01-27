﻿// <copyright file="Author.cs" company="Transilvania University of Brasov">
// Copyright (c) Alexandra Hermeneanu. All rights reserved.
// </copyright>

namespace DomainModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;

    /// <summary>
    /// Author entity class.
    /// </summary>
    public class Author : IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Author"/> class.
        /// </summary>
        public Author()
        {
            Books = new List<Book>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Author"/> class.
        /// </summary>
        /// <param name="firstName">The first name.</param>
        /// <param name="lastName">The last name.</param>
        /// <param name="language">The language.</param>
        /// <param name="dateOfBirth">The date of birth.</param>
        /// <param name="dateOfDeath">The date o death.</param>
        public Author(string firstName, string lastName, string language, DateTime? dateOfBirth, DateTime? dateOfDeath)
        {
            FirstName = firstName;
            LastName = lastName;
            Language = language;
            DateOfBirth = dateOfBirth;
            DateOfDeath = dateOfDeath;
            Books = new List<Book>();
        }

        /// <summary>
        /// Gets or sets the ID of the Author.
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
        /// Gets or sets the language.
        /// </summary>
        [Required(ErrorMessage = ErrorMessages.LanguageRequired)]
        [StringLength(50, ErrorMessage = ErrorMessages.LanguageRangeLength, MinimumLength = 2)]
        public string Language { get; set; }

        /// <summary>
        /// Gets or sets the date of birth.
        /// </summary>
        public DateTime? DateOfBirth { get; set; }

        /// <summary>
        /// Gets or sets the date of death.
        /// </summary>
        public DateTime? DateOfDeath { get; set; }

        /// <summary>
        /// Gets or sets the list of books.
        /// </summary>
        public List<Book> Books { get; set; }

        /// <summary>
        /// Validates the entity.
        /// </summary>
        /// <param name="validationContext">The validation context.</param>
        /// <returns>The validation result and member names.</returns>
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            IList<string> dataMembers = new List<string>();

            if (DateOfBirth != null && DateOfDeath != null && DateOfBirth > DateOfDeath)
            {
                dataMembers.Add("DateOfBirth");
                dataMembers.Add("DateOfDeath");
            }

            if (DateOfBirth != null && DateOfBirth > DateTime.Now)
            {
                dataMembers.Add("DateOfBirth");
            }

            if (DateOfDeath != null && DateOfDeath > DateTime.Now)
            {
                dataMembers.Add("DateOfDeath");
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
            return $"{FirstName} | {LastName} | {Language} | {DateOfBirth.Value.Date.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture)} | {DateOfDeath.Value.Date.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture)} ";
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
            Author author = (Author)obj;
            if (FirstName.Equals(author.FirstName) &&
                LastName.Equals(author.LastName) &&
                Language.Equals(author.Language) &&
                DateOfBirth.Equals(author.DateOfBirth) &&
                DateOfDeath.Equals(author.DateOfDeath))
            {
                return true;
            }

            return false;
        }
    }
}
