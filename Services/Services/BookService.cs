// <copyright file="BookService.cs" company="Transilvania University of Brasov">
// Copyright (c) Transilvania University of Brasov. Code by Alexandra Hermeneanu. All rights reserved.
// </copyright>

namespace Services
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Diagnostics.CodeAnalysis;
    using DataMapper;
    using DomainModel;

    /// <summary>
    /// The implementation class of the IBookService interface.
    /// </summary>
    [SuppressMessage("Microsoft.StyleCop.CSharp.OrderingRules", "SA1101", Justification = "In .NET this is rarely used.")]
    public class BookService : IBookService
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
            ValidationContext context = new ValidationContext(book);
            IList<ValidationResult> validationResults = new List<ValidationResult>();

            return Validator.TryValidateObject(book, context, validationResults, true);
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
    }
}
