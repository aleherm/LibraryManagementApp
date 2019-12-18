using DomainModel;
using NUnit.Framework;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TestDomainModel
{
    [TestFixture]
    public class BookTest
    {
        private Book book;
        private ValidationContext context;
        private IList<ValidationResult> results;

        [SetUp]
        public void BookSetUp()
        {
            book = new Book()
            {
                Id = 1,
                Title = "I don't like you"
            };

            context = new ValidationContext(book, serviceProvider: null, items: null);
            results = new List<ValidationResult>();
        }

        [TestCase]
        public void BookTitleShouldNotBeNull()
        {
            book.Title = null;
           
            bool isValid = Validator.TryValidateObject(book, context, results);

            Assert.IsFalse(isValid);
        }

        [TestCase]
        public void BookEditionListShouldNotBeNull()
        {
            Assert.NotNull(book.Editions);
        }

        [TestCase]
        public void BookAuthorListShouldNotBeNull()
        {
            book.Authors = null;

            bool isValid = Validator.TryValidateObject(book, context, results);

            Assert.IsFalse(isValid);
        }

        [TestCase]
        public void BookDomainListShouldNotBeNull()
        {
            book.Domains = null;

            bool isValid = Validator.TryValidateObject(book, context, results);

            Assert.IsFalse(isValid);
        }

        //[TestCase]
        //public void CheckEntityValidationErrors()
        //{
        //    MyEntityObject myEntityObject = new MyEntityObject();
        //    myEntityObject.myProperty = "1234567890";

        //    var dbContext = new DbContext(MyEntityObject, true);

        //    int errors = dbContext.GetValidationErrors().Count();

        //    IEnumerable<DbEntityValidationResult> validationResults =
        //                                             dbContext.GetValidationErrors();
        //    DbValidationError validationError = validationResults.First().ValidationErrors.First();

        //    Assert.AreEqual(1, errors);
        //    Assert.AreEqual("myProperty", validationError.PropertyName);
        //}
    }
}
