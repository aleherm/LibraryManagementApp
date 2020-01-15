// <copyright file="AuthorServiceTest.cs" company="Transilvania University of Brasov">
// Copyright (c) Alexandra Hermeneanu. All rights reserved.
// </copyright>

namespace TestServices
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using DomainModel;
    using Moq;
    using Newtonsoft.Json;
    using NUnit.Framework;
    using Services;

    [TestFixture]
    public class AuthorServiceTest : ServiceTest
    {
        /// <summary>
        /// The service instance to be tested.
        /// </summary>
        private AuthorService service;

        /// <summary>
        /// The Author entity based on which the tests will run.
        /// </summary>
        private Author author;

        /// <summary>
        /// The setup of the AuthorService object to be tested.
        /// </summary>
        [SetUp]
        public void AuthorServiceSetUp()
        {
            service = new AuthorService();

            author = new Author()
            {
                FirstName = "John",
                LastName = "Smith",
                Language = "English",
                DateOfBirth = new DateTime(1989, 10, 10),
                DateOfDeath = new DateTime(2010, 1, 1),
            };
        }

        [Test]
        public override void AddNewInvalidEntityShouldFail()
        {
            author.FirstName = "I";
            Assert.IsFalse(service.AddNewAuthor(author), "Expected validation to fail");
        }

        [Test]
        public override void AddNewValidEntityShouldBeSuccessful()
        {
            Assert.IsTrue(service.AddNewAuthor(author), "Expected validation to pass");
        }

        [Test]
        public override void EntityShouldBeValid()
        {
            Assert.AreEqual(true, service.IsValidAuthor(author), "Expected validation to pass");
        }

        [Test]
        public override void EntityShouldNotBeValid()
        {
            author.Language = "X";
            Assert.AreEqual(false, service.IsValidAuthor(author), "Expected validation to fail");
        }

        [Test]
        public void GetAllAuthorsValidCall()
        {
            var mockedAuthorService = new Mock<AuthorService>();
            mockedAuthorService.Setup(x => x.GetAllAuthors()).Returns(GetAllSampleAuthors());

            IEnumerable<Author> expected = service.GetAllAuthors();
            IEnumerable<Author> actual = GetAllSampleAuthors();

            Assert.True(EnumerableExtensions.HasSameElementsAs<Author>(expected, actual));
        }

        [Test]
        public void GetAuthorByIdValidCall()
        {
            var mockedAuthorService = new Mock<AuthorService>();
            mockedAuthorService.Setup(x => x.GetAuthorById(It.IsAny<Author>().Id)).Returns(author);

            Assert.AreEqual(author, service.GetAuthorById(1));
        }

        /// <summary>
        /// Gets all sample authors.
        /// </summary>
        /// <returns></returns>
        private IEnumerable<Author> GetAllSampleAuthors()
        {
            List<Author> output = new List<Author>()
            {
                new Author
                {
                    Id = 1,
                    FirstName = "FirstName1",
                    LastName = "LastName1",
                    DateOfBirth = new DateTime(1900, 10, 10),
                    DateOfDeath = new DateTime(1990, 10, 10),
                },
                new Author
                {
                    Id = 2,
                    FirstName = "FirstName2",
                    LastName = "LastNam2",
                    DateOfBirth = new DateTime(1800, 10, 10),
                    DateOfDeath = new DateTime(1880, 10, 10),
                }
            };

            return output;
        }
    }
}
