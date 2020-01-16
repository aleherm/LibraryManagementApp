// <copyright file="BorrowerServiceTest.cs" company="Transilvania University of Brasov">
// Copyright (c) Alexandra Hermeneanu. All rights reserved.
// </copyright>

namespace TestServices
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using DataMapper;
    using DomainModel;
    using Moq;
    using NUnit.Framework;
    using Services;
    
    [TestFixture]
    public class BorrowerServiceTest : ServiceTest
    {
        /// <summary>
        /// The service instance to be tested.
        /// </summary>
        private BorrowerService service;

        /// <summary>
        /// The Borrower entity based on which the tests will run.
        /// </summary>
        private Borrower borrower;

        /// <summary>
        /// The setup of the BorrowerService object to be tested.
        /// </summary>
        [SetUp]
        public void BorrowerServiceSetUp()
        {
            service = new BorrowerService();
            Address address = new Address("Brasov", "Octavian", 10);
            borrower = new Borrower("Alexandra", "Hermeneanu", "ale@email.com", new DateTime(1999, 10, 10), address, true, false);
        }

        [Test]
        public override void EntityShouldBeValid()
        {
            Assert.AreEqual(true, service.IsValidBorrower(borrower));
        }

        [Test]
        public override void EntityShouldNotBeValid()
        {
            borrower.Email = "ceva";
            Assert.AreEqual(false, service.IsValidBorrower(borrower));
        }

        [Test]
        public override void AddNewValidEntityShouldBeSuccessful()
        {
            Assert.AreEqual(true, service.AddNewBorrower(borrower));
        }

        [Test]
        public void AddNewInvalidEntityShouldBeSuccessful()
        {
            Assert.AreEqual(true, service.AddNewBorrower(borrower));
        }

        [Test]
        public override void AddNewInvalidEntityShouldFail()
        {
            borrower.Email = "ceva";
            Assert.AreEqual(false, service.AddNewBorrower(borrower));
        }

        [Test]
        public void GetAllBorrowersValidCall()
        {
            var mockedBorrowerRepository = new Mock<IBorrowerRepository>();
            mockedBorrowerRepository.Setup(x => x.Get(
                It.IsAny<Expression<Func<Borrower, bool>>>(),
                It.IsAny<Func<IQueryable<Borrower>, IOrderedQueryable<Borrower>>>(),
                It.IsAny<string>())).Returns(GetAllSampleBorrowers());

            IBorrowerService mockService = new BorrowerService(mockedBorrowerRepository.Object);

            IEnumerable<Borrower> expected = GetAllSampleBorrowers();
            IEnumerable<Borrower> actual = mockService.GetAllBorrowers();

            Assert.True(EnumerableExtensions.HasSameElementsAs<Borrower>(expected, actual));
        }

        [Test]
        public void GetBorrowerByIdValidCall()
        {
            var mockedBorrowerRepository = new Mock<IBorrowerRepository>();
            mockedBorrowerRepository.Setup(x => x.GetByID(It.IsAny<int>())).Returns(borrower);

            IBorrowerService mockService = new BorrowerService(mockedBorrowerRepository.Object);
            Borrower expected = borrower;
            Borrower actual = mockService.GetBorrowerById(1);

            Assert.AreEqual(expected, actual, "Expected to have the same values");
        }

        /// <summary>
        /// Gets all sample borrowers.
        /// </summary>
        /// <returns></returns>
        private IEnumerable<Borrower> GetAllSampleBorrowers()
        {
            List<Borrower> output = new List<Borrower>()
            {
                new Borrower()
                {
                    Id = 1,
                    FirstName = "Alexandra",
                    LastName = "Hermeneanu",
                    Email = "ale.herm@email.com",
                    Gender = EGenderType.EFemale,
                    Address = new Address(),
                    Loans = new List<Loan> { new Loan() },
                    ReaderFlg = true,
                    LibrarianFlg = false,
                },
                new Borrower
                {
                    Id = 1,
                    FirstName = "Nicolae",
                    LastName = "Hermeneanu",
                    Email = "nic@email.com",
                    Gender = EGenderType.EMale,
                    Address = new Address(),
                    Loans = new List<Loan> { new Loan() },
                    ReaderFlg = true,
                    LibrarianFlg = false,
                },
            };

            return output;
        }
    }
}
