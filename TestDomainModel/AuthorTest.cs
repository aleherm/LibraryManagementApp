using DomainModel;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TestDomainModel
{
    [TestFixture]
    public class AuthorTest
    {
        private Author author;

        [SetUp]
        public void AuthorSetUp()
        {
            author = new Author()
            {
                FirstName = "John",
                LastName = "Smith",
                Language = "English",
                DateOfBirth = new DateTime(1989, 10, 10),
                DateOfDeath = new DateTime(2010, 1, 1)
            };
        }

        [Test]
        public void FirstNameShouldNotBeNull()
        {
            author.FirstName = null;

            var context = new ValidationContext(author, serviceProvider: null, items: null);
            var results = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(author, context, results);

            Assert.IsFalse(isValid);
        }

        [Test]
        public void LastNameShouldNotBeNull()
        {
            author.LastName = null;

            var context = new ValidationContext(author, serviceProvider: null, items: null);
            var results = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(author, context, results);

            Assert.IsFalse(isValid);
        }

        [Test]
        public void LanguageShouldNotBeNull()
        {
            author.Language = null;

            var context = new ValidationContext(author, serviceProvider: null, items: null);
            var results = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(author, context, results);

            Assert.IsFalse(isValid);
        }

        [Test]
        public void FirstNameShouldHaveLessThan50Chars()
        {
            author.FirstName = new string('a', 51);

            var context = new ValidationContext(author, serviceProvider: null, items: null);
            var results = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(author, context, results);

            Assert.IsFalse(isValid);
        }
    }
}
