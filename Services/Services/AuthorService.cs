// <copyright file="AuthorService.cs" company="Transilvania University of Brasov">
// Copyright (c) Alexandra Hermeneanu. All rights reserved.
// </copyright>

namespace Services
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using DataMapper;
    using DomainModel;

    /// <summary>
    /// Author Service class.
    /// </summary>
    public class AuthorService
    {
        private readonly AuthorRepository authorRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthorService"/> class.
        /// </summary>
        public AuthorService()
        {
            authorRepository = new AuthorRepository();
        }

        /// <summary>
        /// Validates the given Author object.
        /// </summary>
        /// <param name="author">The author.</param>
        /// <returns>True or False.</returns>
        public bool IsValidAuthor(Author author)
        {
            ValidationContext context = new ValidationContext(author);
            IList<ValidationResult> validationResults = new List<ValidationResult>();

            return Validator.TryValidateObject(author, context, validationResults, true);
        }

        /// <summary>
        /// Inserts a new Author object in the database.
        /// </summary>
        /// <param name="author">The author.</param>
        /// <returns>True or False.</returns>
        public bool AddNewAuthor(Author author)
        {
            if (IsValidAuthor(author))
            {
                authorRepository.Insert(author);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Gets the list of authors.
        /// </summary>
        /// <returns>The list of authors.</returns>
        public IEnumerable<Author> GetAllAuthors()
        {
            return authorRepository.Get(
                 orderBy: q => q.OrderBy(c => c.FirstName));
        }

        /// <summary>
        /// Gets the author by given ID.
        /// </summary>
        /// <param name="idAuthor">The ID of the author.</param>
        /// <returns>The Author object found.</returns>
        public Author GetAuthorById(int idAuthor)
        {
            return authorRepository.GetByID(idAuthor);
        }
    }
}
