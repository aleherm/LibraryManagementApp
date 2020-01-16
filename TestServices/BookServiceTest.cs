// <copyright file="BookServiceTest.cs" company="Transilvania University of Brasov">
// Copyright (c) Alexandra Hermeneanu. All rights reserved.
// </copyright>

namespace TestServices
{
    using System;
    using System.Collections.Generic;
    using DomainModel;
    using Moq;
    using NUnit.Framework;
    using Services;

    [TestFixture]
    public class BookServiceTest : ServiceTest
    {
        /// <summary>
        /// The service instance to be tested.
        /// </summary>
        private BookService service;

        /// <summary>
        /// The Book entity based on which the tests will run.
        /// </summary>
        private Book book;

        [SetUp]
        public void BookSetUp()
        {
            service = new BookService();

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
                        DomainName = "Mathematics",
                        ParentDomain = new Domain()
                        {
                            DomainName = "Science",
                            ParentDomain = null,
                        },
                    },
                },
            };
        }

        [Test]
        public override void EntityShouldBeValid()
        {
            Assert.AreEqual(true, service.IsValidBook(book), "Expected validation to pass");
        }

        [Test]
        public override void EntityShouldNotBeValid()
        {
            book.Domains = new List<Domain>();
            Assert.AreEqual(false, service.IsValidBook(book), "Expected validation to fail.");
        }

        [Test]
        public override void AddNewValidEntityShouldBeSuccessful()
        {
            Assert.AreEqual(true, service.AddNewBook(book), "Expected validation to pass");
        }

        [Test]
        public override void AddNewInvalidEntityShouldFail()
        {
            book.Domains = new List<Domain>();
            Assert.AreEqual(false, service.AddNewBook(book), "Expected validation to fail");
        }

        [Test]
        public void BookShouldNotHaveTooManyDomains()
        {
            // Added more domains than specified in threshold file.
            book.Domains.Add(new Domain());
            book.Domains.Add(new Domain());

            Assert.AreEqual(false, service.IsValidBook(book), "Expected to fail.");
            Assert.AreEqual(1, service.ErrorsHandler.ErrorCount(), "Unexpected number of errors.");
            Assert.AreEqual(ValidationErrors.TooManyDomains, service.ErrorsHandler.Get(0));
        }

        [Test]
        public void BookShouldBeValidWithNonRelatedDomains()
        {
            // Added 2 non-related domains within the threshold range.
            book.Domains = new List<Domain>();
            Domain parentDomain = new Domain("Parent", null, null, null);
            Domain childDomain1 = new Domain("Domain1", parentDomain, null, new List<Book>() { book });
            Domain childDomain2 = new Domain("Domain2", parentDomain, null, new List<Book>() { book });
            book.Domains.Add(childDomain1);
            book.Domains.Add(childDomain2);

            Assert.AreEqual(true, service.IsValidBook(book), "Expected to pass.");
            Assert.AreEqual(0, service.ErrorsHandler.ErrorCount(), "Unexpected number of errors.");
        }

        [Test]
        public void BookShouldNotHaveRelatedDomains()
        {
            // Added 2 related domains within the threshold range.
            book.Domains = new List<Domain>();
            Domain parentDomain = new Domain("Parent", null, null, null);
            Domain childDomain1 = new Domain("Domain1", parentDomain, null, null);
            Domain childDomain2 = parentDomain;
            book.Domains.Add(childDomain1);
            book.Domains.Add(childDomain2);

            Assert.AreEqual(false, service.IsValidBook(book), "Expected to fail.");
            Assert.AreEqual(1, service.ErrorsHandler.ErrorCount(), "Unexpected number of errors.");
            Assert.AreEqual(ValidationErrors.DomainAreRelated, service.ErrorsHandler.Get(0));
        }

        [Test]
        public void GetAllBookesValidCall()
        {
            var mockedBookService = new Mock<IBookService>();
            mockedBookService.Setup(x => x.GetAllBooks()).Returns(GetAllSampleBooks());

            IBookService mockService = mockedBookService.Object;

            IEnumerable<Book> expected = mockService.GetAllBooks();
            IEnumerable<Book> actual = GetAllSampleBooks();

            Assert.True(EnumerableExtensions.HasSameElementsAs<Book>(expected, actual));
        }

        [Test]
        public void GetBookByIdValidCall()
        {
            var mockedBookService = new Mock<IBookService>();
            mockedBookService.Setup(x => x.GetBookById(It.IsAny<int>())).Returns(book);

            IBookService mockService = mockedBookService.Object;
            Book expected = book;
            Book actual = mockService.GetBookById(1);

            Assert.AreEqual(expected, actual, "Expected to have the same values");
        }

        /// <summary>
        /// Gets all sample addresses.
        /// </summary>
        /// <returns></returns>
        private IEnumerable<Book> GetAllSampleBooks()
        {
            List<Book> output = new List<Book>()
            {
                new Book()
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
                },
            };

            return output;
        }
    }
}
