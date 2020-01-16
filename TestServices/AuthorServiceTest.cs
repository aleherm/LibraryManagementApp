// <copyright file="AuthorServiceTest.cs" company="Transilvania University of Brasov">
// Copyright (c) Alexandra Hermeneanu. All rights reserved.
// </copyright>

namespace TestServices
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Linq.Expressions;
    using DataMapper;
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
        private IAuthorService service;

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
            var mockedAuthorRepository = new Mock<IAuthorRepository>();
            mockedAuthorRepository.Setup(x => x.Get(
                It.IsAny<Expression<Func<Author, bool>>>(),
                It.IsAny<Func<IQueryable<Author>, IOrderedQueryable<Author>>>(),
                It.IsAny<string>())).Returns(GetAllSampleAuthors());

            IAuthorService mockService = new AuthorService(mockedAuthorRepository.Object);

            IEnumerable<Author> expected = mockService.GetAllAuthors();
            IEnumerable<Author> actual = GetAllSampleAuthors();

            Assert.True(EnumerableExtensions.HasSameElementsAs<Author>(expected, actual));
        }

        [Test]
        public void GetAuthorByIdValidCall()
        {
            var mockedAuthorRepository = new Mock<IAuthorRepository>();
            mockedAuthorRepository.Setup(x => x.GetByID(It.IsAny<int>())).Returns(author);

            IAuthorService mockService = new AuthorService(mockedAuthorRepository.Object);
            Author expected = author;
            Author actual = mockService.GetAuthorById(1);

            Assert.AreEqual(expected, actual, "Expected to have the same values");
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
                    Language = "Language",
                    DateOfBirth = new DateTime(1900, 10, 10),
                    DateOfDeath = new DateTime(1990, 10, 10),
                },
                new Author
                {
                    Id = 2,
                    FirstName = "FirstName2",
                    LastName = "LastName2",
                    Language = "Language",
                    DateOfBirth = new DateTime(1800, 10, 10),
                    DateOfDeath = new DateTime(1880, 10, 10),
                }
            };

            return output;
        }
    }
}
