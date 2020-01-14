// <copyright file="IAuthorService.cs" company="Transilvania University of Brasov">
// Copyright (c) Alexandra Hermeneanu. All rights reserved.
// </copyright>

namespace Services
{
    using System.Collections.Generic;
    using DomainModel;

    /// <summary>
    /// Interface for the AuthorService.
    /// </summary>
    internal interface IAuthorService
    {
        /// <summary>
        /// Validates the given Author object.
        /// </summary>
        /// <param name="author">The author.</param>
        /// <returns>True or False.</returns>
        bool IsValidAuthor(Author author);

        /// <summary>
        /// Inserts a new Author object in the database.
        /// </summary>
        /// <param name="author">The author.</param>
        /// <returns>True or false.</returns>
        bool AddNewAuthor(Author author);

        /// <summary>
        /// Gets the list of all authors.
        /// </summary>
        /// <returns>The list of authors.</returns>
        IEnumerable<Author> GetAllAuthors();

        /// <summary>
        /// Gets the author by given ID.
        /// </summary>
        /// <param name="idAuthor">The ID of the author.</param>
        /// <returns>The Author object found.</returns>
        Author GetAuthorById(int idAuthor);
    }
}
