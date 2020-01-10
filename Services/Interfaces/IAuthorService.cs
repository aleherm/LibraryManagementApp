using DomainModel;
using System.Collections.Generic;

namespace Services
{
    interface IAuthorService
    {
        bool IsValidAuthor(Author author);
        bool AddNewAuthor(Author author);
        IEnumerable<Author> GetAllAuthors();
        Author GetAuthorById(int idAuthor);
    }
}
