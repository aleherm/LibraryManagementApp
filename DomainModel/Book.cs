// <copyright file="Book.cs" company="Transilvania University of Brasov">
// Copyright (c) Alexandra Hermeneanu. All rights reserved.
// </copyright>

namespace DomainModel
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Book entity class.
    /// </summary>
    public class Book : IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Book"/> class.
        /// </summary>
        public Book()
        {
            Authors = new List<Author>();
            Domains = new List<Domain>();
            Editions = new List<Edition>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Book"/> class.
        /// </summary>
        /// <param name="title">The book title.</param>
        /// <param name="authors">The list of authors.</param>
        /// <param name="domains">The list of domains.</param>
        /// <param name="editions">The list of editions.</param>
        public Book(string title, List<Author> authors, List<Domain> domains, List<Edition> editions)
        {
            Title = title;
            Authors = authors;
            Domains = domains;
            Editions = editions;
        }

        /// <summary>
        /// Gets or sets the ID of the book.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the title of the book.
        /// </summary>
        [Required(ErrorMessage = ErrorMessages.BookTitleRequired)]
        [StringLength(100, MinimumLength = 2, ErrorMessage = ErrorMessages.BookTitleRangeLength)]
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the list of authors.
        /// </summary>
        [Required(ErrorMessage = ErrorMessages.AuthorRequired)]
        public IList<Author> Authors { get; set; }

        /// <summary>
        /// Gets or sets the list of domains.
        /// </summary>
        [Required(ErrorMessage = ErrorMessages.DomainRequired)]
        public IList<Domain> Domains { get; set; }

        /// <summary>
        /// Gets or sets the list of editions.
        /// </summary>
        [Required(ErrorMessage = ErrorMessages.EditionRequired)]
        public IList<Edition> Editions { get; set; }

        /// <summary>
        /// Validates the Book entity.
        /// </summary>
        /// <param name="validationContext">The validation context.</param>
        /// <returns>Output string for a Book entity.</returns>
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<string> memberNames = new List<string>();

            if (Authors != null && Authors.Count == 0)
            {
                memberNames.Add("Authors");
            }

            if (Domains != null && Domains.Count == 0)
            {
                memberNames.Add("Domains");
            }

            if (Editions != null && Editions.Count == 0)
            {
                memberNames.Add("Editions");
            }

            if (memberNames.Count != 0)
            {
                yield return new ValidationResult(ErrorMessages.ListRequireAtLeastOneObject, memberNames);
            }

            yield return null;
        }
    }
}
