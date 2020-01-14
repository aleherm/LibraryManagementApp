// <copyright file="Domain.cs" company="Transilvania University of Brasov">
// Copyright (c) Alexandra Hermeneanu. All rights reserved.
// </copyright>

namespace DomainModel
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Domain entity class.
    /// </summary>
    public class Domain
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Domain"/> class.
        /// </summary>
        public Domain()
        {
            Subdomains = new List<Domain>();
            Books = new List<Book>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Domain" /> class.
        /// </summary>
        /// <param name="domainName">The domain name.</param>
        /// <param name="parent">The parent domain name.</param>
        /// <param name="subdomains">The subdomains list.</param>
        /// <param name="books">The books list.</param>
        public Domain(string domainName, Domain parent, List<Domain> subdomains, List<Book> books)
        {
            DomainName = domainName;
            ParentDomain = parent;
            Subdomains = subdomains;
            Books = books;
        }

        /// <summary>
        /// Gets or sets the ID of the borrower.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the domain name.
        /// </summary>
        [Required(ErrorMessage = ErrorMessages.DomainNameRequired)]
        [StringLength(100, ErrorMessage = ErrorMessages.DomainNameRangeLength, MinimumLength = 5)]
        public string DomainName { get; set; }

        /// <summary>
        /// Gets or sets the parent domain.
        /// </summary>
        public Domain ParentDomain { get; set; }

        /// <summary>
        /// Gets or sets the list of subdomains.
        /// </summary>
        [Required(ErrorMessage = ErrorMessages.SubdomainRequired)]
        public IList<Domain> Subdomains { get; set; }

        /// <summary>
        /// Gets or sets the list of books.
        /// </summary>
        public List<Book> Books { get; set; }

        /// <summary>
        /// Shows the data of the current entity.
        /// </summary>
        /// <returns>Output string for an Domain entity.</returns>
        public override string ToString()
        {
            return $"{DomainName} | {ParentDomain}";
        }
    }
}
