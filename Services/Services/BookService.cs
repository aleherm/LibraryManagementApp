// <copyright file="BookService.cs" company="Transilvania University of Brasov">
// Copyright (c) Alexandra Hermeneanu. All rights reserved.
// </copyright>

namespace Services
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using DataMapper;
    using DomainModel;

    /// <summary>
    /// The implementation class of the IBookService interface.
    /// </summary>
    public class BookService : Service, IBookService
    {
        private BookRepository bookRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="BookService"/> class.
        /// </summary>
        public BookService()
        {
            bookRepository = new BookRepository();
        }

        /// <summary>
        /// Validates the given Book object.
        /// </summary>
        /// <param name="book">The book.</param>
        /// <returns>True or False.</returns>
        public bool IsValidBook(Book book)
        {
            bool isValid = true;

            ValidationContext context = new ValidationContext(book);
            IList<ValidationResult> validationResults = new List<ValidationResult>();

            isValid = Validator.TryValidateObject(book, context, validationResults, true);

            if (validationResults.Count != 0)
            {
                foreach (ValidationResult result in validationResults)
                {
                    ErrorsHandler.Add(result.ErrorMessage);
                }

                isValid = false;
            }

            if (!isValid)
            {
                return false;
            }

            if (book.Domains.Count > Threshold.NoMaxDomains)
            {
                ErrorsHandler.Add(ValidationErrors.TooManyDomains);
                isValid = false;
            }

            if (!isValid)
            {
                return false;
            }

            if (AreRelatedDomains(book.Domains))
            {
                ErrorsHandler.Add(ValidationErrors.DomainAreRelated);
                isValid = false;
            }

            return isValid;
        }
        
        /// <summary>
        /// Inserts a new Book object in the database.
        /// </summary>
        /// <param name="book">The book.</param>
        /// <returns>True or false.</returns>
        public bool AddNewBook(Book book)
        {
            if (IsValidBook(book))
            {
                bookRepository.Insert(book);
                return true;
            }
            else
            {
                ErrorsHandler.PrintErrors();
            }

            return false;
        }

        /// <summary>
        /// Gets the book by given ID.
        /// </summary>
        /// <param name="idBook">The ID of the book.</param>
        /// <returns>The Book object found.</returns>
        public Book GetBookById(int idBook)
        {
            return bookRepository.GetByID(idBook);
        }

        /// <summary>
        /// Determines whether the specified domains are related.
        /// </summary>
        /// <param name="domains">The domains list.</param>
        /// <returns>
        ///   <c>true</c> if one domain related to others; otherwise, <c>false</c>.
        /// </returns>
        private bool AreRelatedDomains(IList<Domain> domains)
        {
            List<Domain> parentDomains = new List<Domain>();

            Domain domain = domains[0];
            while (domain.ParentDomain != null)
            {
                parentDomains.Add(domain.ParentDomain);
                domain = domain.ParentDomain;
            }

            for (int i = 1; i < domains.Count; i++)
            {
                domain = domains[i];
                if (parentDomains.Contains(domain))
                {
                    return true;
                }
                else
                {
                    while (domain.ParentDomain != null)
                    {
                        if (!parentDomains.Contains(domain.ParentDomain))
                        {
                            parentDomains.Add(domain.ParentDomain);
                        }

                        domain = domain.ParentDomain;
                    }
                }
            }

            return false;
        }
    }
}
