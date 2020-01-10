using DataMapper;
using DomainModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Services
{
    public class BookService : IBookService
    {
        private BookRepository bookRepository;

        public BookService()
        {
            bookRepository = new BookRepository();
        }

        public bool IsValidBook(Book book)
        {
            ValidationContext context = new ValidationContext(book);
            IList<ValidationResult> validationResults = new List<ValidationResult>();

            return Validator.TryValidateObject(book, context, validationResults, true);
        }

        public bool AddNewBook(Book book)
        {
            if(IsValidBook(book))
            {
                bookRepository.Insert(book);
                return true;
            }
            return false;
        }

        public Book GetBookById(int idBook)
        {
            return bookRepository.GetByID(idBook);
        }
    }
}
