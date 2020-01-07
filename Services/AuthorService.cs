using DataMapper;
using DomainModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class AuthorService
    {
        private AuthorRepository authorRepository;

        public AuthorService()
        {
            authorRepository = new AuthorRepository();
        }

        private bool IsValidAuthor(Author author)
        {
            ValidationContext context = new ValidationContext(author);
            IList<ValidationResult> validationResults = new List<ValidationResult>();

            return Validator.TryValidateObject(author, context, validationResults, true);
        }

        public bool AddNewAuthor(string firstName, string lastName, string language, DateTime dateOfBirth, DateTime dateOfDeath)
        {
            Author newAuthor = new Author(firstName, lastName, language, dateOfBirth, dateOfDeath);
            if (IsValidAuthor(newAuthor))
            {
                authorRepository.Insert(newAuthor);
                return true;
            }
            return false;
        }
    }
}
