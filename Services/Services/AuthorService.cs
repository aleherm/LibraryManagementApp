using DataMapper;
using DomainModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Services
{
    public class AuthorService : IAuthorService
    {
        private AuthorRepository authorRepository;

        public AuthorService()
        {
            authorRepository = new AuthorRepository();
        }

        public bool IsValidAuthor(Author author)
        {
            ValidationContext context = new ValidationContext(author);
            IList<ValidationResult> validationResults = new List<ValidationResult>();

            return Validator.TryValidateObject(author, context, validationResults, true);
        }

        public bool AddNewAuthor(Author author)
        {
            if (IsValidAuthor(author))
            {
                authorRepository.Insert(author);
                return true;
            }
            return false;
        }

        public IEnumerable<Author> GetAllAuthors()
        {
            return authorRepository.Get(
                 orderBy: q => q.OrderBy(c => c.FirstName));
        }

        public Author GetAuthorById(int idAuthor)
        {
            return authorRepository.GetByID(idAuthor);
        }
    }
}
