using DataMapper;
using DomainModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Services
{
    public class BookService
    {
        private BookRepository bookRepository;

        public BookService()
        {
            bookRepository = new BookRepository();
        }

        private bool IsValidBook(Book book)
        {
            ValidationContext context = new ValidationContext(book);
            IList<ValidationResult> validationResults = new List<ValidationResult>();

            return Validator.TryValidateObject(book, context, validationResults, true);
        }

        public void AddNewBook()
        {
            throw new NotImplementedException();
        }

        public Book getBook(int id)
        {
            return bookRepository.GetByID(id);
        }
    }
}
