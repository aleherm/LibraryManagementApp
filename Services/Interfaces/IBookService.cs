// <copyright file="IBookService.cs" company="Transilvania University of Brasov">
// Copyright (c) Alexandra Hermeneanu. All rights reserved.
// </copyright>

namespace Services
{
    using System.Collections.Generic;
    using DomainModel;

    /// <summary>
    /// Interface for the BookService.
    /// </summary>
    public interface IBookService
    {
        /// <summary>
        /// Validates the given Book object.
        /// </summary>
        /// <param name="book">The book.</param>
        /// <returns>True or False.</returns>
        bool IsValidBook(Book book);

        /// <summary>
        /// Inserts a new Book object in the database.
        /// </summary>
        /// <param name="book">The book.</param>
        /// <returns>True or false.</returns>
        bool AddNewBook(Book book);

        /// <summary>
        /// Gets the list of books.
        /// </summary>
        /// <returns>The list of books.</returns>
        IEnumerable<Book> GetAllBooks();

        /// <summary>
        /// Gets the book by given ID.
        /// </summary>
        /// <param name="idBook">The ID of the book.</param>
        /// <returns>The Book object found.</returns>
        Book GetBookById(int idBook);
    }
}