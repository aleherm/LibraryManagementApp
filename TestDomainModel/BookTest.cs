// <copyright file="BookTest.cs" company="Transilvania University of Brasov">
// Copyright (c) Transilvania University of Brasov. Code by Alexandra Hermeneanu. All rights reserved.
// </copyright>

namespace TestDomainModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using DomainModel;
    using NUnit.Framework;

    /// <summary>
    /// The Book test class.
    /// </summary>
    [TestFixture]
    public class BookTest
    {
        /// <summary>
        /// Book object to test.
        /// </summary>
        private Book book;

        /// <summary>
        /// The Address validation context.
        /// </summary>
        private ValidationContext context;

        /// <summary>
        /// Validation errors returned.
        /// </summary>
        private IList<ValidationResult> validationResults;

        [SetUp]
        public void BookSetUp()
        {
            book = new Book()
            {
                Title = "Something odd",
                Authors = new List<Author>
                {
                    new Author()
                    {
                        FirstName = "John",
                        LastName = "Smith",
                        Language = "English",
                        DateOfBirth = new DateTime(1989, 10, 10),
                        DateOfDeath = new DateTime(2010, 1, 1),
                    },
                },
                Editions = new List<Edition>
                {
                    new Edition()
                    {
                        PageNumber = 100,
                        Year = 2019,
                        BookType = EBookType.EHardCover,
                        Publisher = "Humanitas",
                        NoTotal = 10,
                        NoForLibrary = 2,
                        NoForLoan = 8,
                    },
                },
                Domains = new List<Domain>
                {
                    new Domain()
                    {
                        DomainName = "Math",
                        ParentDomain = new Domain()
                        {
                            DomainName = "Science",
                            ParentDomain = null,
                        },
                    },
                },
            };

            context = new ValidationContext(book);
            validationResults = new List<ValidationResult>();
        }

        [TestCase]
        public void BookTitleShouldNotBeNull()
        {
            book.Title = null;

            var actual = Validator.TryValidateObject(book, context, validationResults, true);

            // Assert
            Assert.IsFalse(actual, "Expected validation to fail.");
            Assert.AreEqual(1, validationResults.Count, "Unexpected number of validation errors.");
            var msg = validationResults[0];
            Assert.AreEqual(ErrorMessages.BookTitleRequired, msg.ErrorMessage);
        }

        [TestCase]
        public void BookEditionListShouldNotBeNull()
        {
            book.Editions = null;

            var actual = Validator.TryValidateObject(book, context, validationResults, true);

            // Assert
            Assert.IsFalse(actual, "Expected validation to fail.");
            Assert.AreEqual(1, validationResults.Count, "Unexpected number of validation errors.");
            var msg = validationResults[0];
            Assert.AreEqual(ErrorMessages.EditionRequired, msg.ErrorMessage);

            Assert.IsNull(book.Editions, "Edition list expected to be null");
        }

        [TestCase]
        public void BookAuthorListShouldNotBeNull()
        {
            book.Authors = null;

            var actual = Validator.TryValidateObject(book, context, validationResults, true);

            // Assert
            Assert.IsFalse(actual, "Expected validation to fail.");
            Assert.AreEqual(1, validationResults.Count, "Unexpected number of validation errors.");
            var msg = validationResults[0];
            Assert.AreEqual(ErrorMessages.AuthorRequired, msg.ErrorMessage);

            Assert.IsNull(book.Authors, "Authors list expected to be null");
        }

        [TestCase]
        public void BookDomainListShouldNotBeNull()
        {
            book.Domains = null;

            var actual = Validator.TryValidateObject(book, context, validationResults, true);

            // Assert
            Assert.IsFalse(actual, "Expected validation to fail.");
            Assert.AreEqual(1, validationResults.Count, "Unexpected number of validation errors.");
            var msg = validationResults[0];
            Assert.AreEqual(ErrorMessages.DomainRequired, msg.ErrorMessage);

            Assert.IsNull(book.Domains, "Domains lsit expected to be null");
        }

        [Test]
        public void BookShouldNotHaveLessThan2Characters()
        {
            book.Title = "X";

            bool actual = Validator.TryValidateObject(book, context, validationResults, true);

            // Assert
            Assert.IsFalse(actual, "Expected validation to fail.");
            Assert.AreEqual(1, validationResults.Count, "Unexpected number of validation errors.");
        }

        [Test]
        public void TitleBetween2And50CharactersShouldBeValid()
        {
            bool actual = Validator.TryValidateObject(book, context, validationResults, true);

            // Assert
            Assert.IsTrue(actual, "Expected validation to pass.");
            Assert.AreEqual(0, validationResults.Count, "Unexpected number of validation errors.");
        }

        [Test]
        public void TitleShouldNotHaveMoreThan100Characters()
        {
            book.Title = new string('x', 101);

            bool actual = Validator.TryValidateObject(book, context, validationResults, true);

            // Assert
            Assert.IsFalse(actual, "Expected validation to fail.");
            Assert.AreEqual(1, validationResults.Count, "Unexpected number of validation errors.");
        }

        [Test]
        public void AuthorListShouldHaveAtLeastOneAuthor()
        {
            book.Authors = new List<Author>();

            bool actual = Validator.TryValidateObject(book, context, validationResults, true);

            // Assert
            Assert.IsFalse(actual, "Expected validation to fail.");
            Assert.AreEqual(1, validationResults.Count, "Unexpected number of validation errors.");

            var msg = validationResults[0];
            Assert.AreEqual(ErrorMessages.ListRequireAtLeastOneObject, msg.ErrorMessage);

            Assert.AreEqual(1, msg.MemberNames.Where(item => item == "Authors").Count());
        }

        [Test]
        public void DomainListShouldHaveAtLeastOneAuthor()
        {
            book.Domains = new List<Domain>();

            bool actual = Validator.TryValidateObject(book, context, validationResults, true);

            // Assert
            Assert.IsFalse(actual, "Expected validation to fail.");
            Assert.AreEqual(1, validationResults.Count, "Unexpected number of validation errors.");

            var msg = validationResults[0];
            Assert.AreEqual(ErrorMessages.ListRequireAtLeastOneObject, msg.ErrorMessage);

            Assert.AreEqual(1, msg.MemberNames.Where(item => item == "Domains").Count());
        }

        [Test]
        public void EditionListShouldHaveAtLeastOneAuthor()
        {
            book.Editions = new List<Edition>();

            bool actual = Validator.TryValidateObject(book, context, validationResults, true);

            // Assert
            Assert.IsFalse(actual, "Expected validation to fail.");
            Assert.AreEqual(1, validationResults.Count, "Unexpected number of validation errors.");

            var msg = validationResults[0];
            Assert.AreEqual(ErrorMessages.ListRequireAtLeastOneObject, msg.ErrorMessage);
            Assert.AreEqual(1, msg.MemberNames.Where(item => item == "Editions").Count());
        }
    }
}
