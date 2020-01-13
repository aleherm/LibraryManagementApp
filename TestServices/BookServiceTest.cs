namespace TestServices
{
    using DomainModel;
    using Newtonsoft.Json;
    using NUnit.Framework;
    using Services;
    using System;
    using System.Collections.Generic;
    using System.IO;

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

        /// <summary>
        /// The threshold item needed to validate loan data.
        /// </summary>
        private Threshold threshold;

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

            string solutionDirectory = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(TestContext.CurrentContext.TestDirectory)));
            threshold = GetThresholdFromJSON(solutionDirectory);
        }
        
        [Test]
        public override void EntityShouldBeValid()
        {
            Assert.AreEqual(service.IsValidBook(book), true);
        }

        [Test]
        public override void EntityShouldNotBeValid()
        {
            Assert.AreEqual(service.IsValidBook(book), true);
        }
        
        [Test]
        public override void AddNewValidEntityShouldBeSuccessful()
        {
            Assert.AreEqual(service.AddNewBook(book), true);
        }

        [Test]
        public override void AddNewInvalidEntityShouldFail()
        {
            book.Domains = new List<Domain>();
            Assert.AreEqual(service.AddNewBook(book), false);
        }

        [Test]
        public void NewValidEntityShouldNotHaveTooManyDomains()
        {
        }
    }
}
