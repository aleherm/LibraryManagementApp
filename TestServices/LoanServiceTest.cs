// <copyright file="ServiceTest.cs" company="Transilvania University of Brasov">
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
    public class LoanServiceTest : ServiceTest
    {
        /// <summary>
        /// The service instance to be tested.
        /// </summary>
        private LoanService service;

        /// <summary>
        /// The Loan entity based on which the tests will run.
        /// </summary>
        private Loan loan;

        [SetUp]
        public void LoanSetUp()
        {
            service = new LoanService();

            loan = new Loan()
            {
                Id = 1,
                LoanDate = new DateTime(2019, 1, 1),
                DueDate = new DateTime(2019, 2, 1),
                ReturnDate = new DateTime(2019, 10, 10),
            };
        }

        [Test]
        public override void AddNewInvalidEntityShouldFail()
        {
            loan.LoanDate = DateTime.Now.AddDays(1);
            Assert.IsFalse(service.AddNewLoan(loan), "Expected validation to fail");
        }

        [Test]
        public override void AddNewValidEntityShouldBeSuccessful()
        {
            Assert.IsTrue(service.AddNewLoan(loan), "Expected validation to pass");
        }

        [Test]
        public override void EntityShouldBeValid()
        {
            Assert.AreEqual(true, service.IsValidLoan(loan), "Expected validation to pass");
        }

        [Test]
        public override void EntityShouldNotBeValid()
        {
            loan.LoanDate = DateTime.Now.AddDays(1);
            Assert.AreEqual(false, service.IsValidLoan(loan), "Expected validation to fail");
        }

        [Test]
        public void LoanShouldNotBeMadeWhenNoBooksForLoan()
        {
            Edition edition = new Edition("Name", 200, 2000, EBookType.EHardCover, 10, 0);
            Book book = new Book("Title", null, null, new List<Edition>() { edition });
            
            loan.BorrowedEditions.Add(book.Editions[0]);
            edition.Loans.Add(loan);

            Assert.AreEqual(false, service.IsValidLoan(loan), "Expected validation to fail");
        }

        [Test]
        public void LoanShouldNotBeMadeWhenLessThan10PercentOfTotalBooksForLoan()
        {
            Edition edition = new Edition("Name", 200, 2000, EBookType.EHardCover, 20, 2);
            Book book = new Book("Title", null, null, new List<Edition>() { edition });

            loan.BorrowedEditions.Add(book.Editions[0]);
            edition.Loans.Add(loan);

            Assert.AreEqual(false, service.IsValidLoan(loan), "Expected validation to fail.");
        }

        [Test]
        public void LoanShouldNotContainMoreThanThresholdBooks()
        {
            Edition edition = new Edition("Publisher", 200, 2000, EBookType.EHardCover, 20, 2);
            Book book1 = new Book("Title1", null, null, new List<Edition>() { edition });
            Book book2 = new Book("Title2", null, null, new List<Edition>() { edition });
            Book book3 = new Book("Title3", null, null, new List<Edition>() { edition });

            loan.BorrowedEditions.Add(book1.Editions[0]);
            loan.BorrowedEditions.Add(book2.Editions[0]);
            loan.BorrowedEditions.Add(book3.Editions[0]);
            edition.Loans.Add(loan);

            Assert.AreEqual(false, service.IsValidLoan(loan), "Expected validation to fail.");
        }

        [Test]
        public void GetAllLoansValidCall()
        {
            var mockedLoanRepository = new Mock<ILoanRepository>();
            mockedLoanRepository.Setup(x => x.Get(
                It.IsAny<Expression<Func<Loan, bool>>>(),
                It.IsAny<Func<IQueryable<Loan>, IOrderedQueryable<Loan>>>(),
                It.IsAny<string>())).Returns(GetAllSampleLoans());

            ILoanService mockService = new LoanService(mockedLoanRepository.Object);

            IEnumerable<Loan> expected = mockService.GetAllLoans();
            IEnumerable<Loan> actual = GetAllSampleLoans();

            Assert.True(EnumerableExtensions.HasSameElementsAs<Loan>(expected, actual));
        }

        [Test]
        public void GetLoansByIdValidCall()
        {
            var mockedLoanRepository = new Mock<ILoanRepository>();
            mockedLoanRepository.Setup(x => x.GetByID(It.IsAny<int>())).Returns(loan);

            ILoanService mockService = new LoanService(mockedLoanRepository.Object);
            Loan expected = loan;
            Loan actual = mockService.GetLoanById(1);

            Assert.AreEqual(expected, actual, "Expected to have the same values");
        }

        /// <summary>
        /// Gets all sample loans.
        /// </summary>
        /// <returns></returns>
        private IEnumerable<Loan> GetAllSampleLoans()
        {
            List<Loan> output = new List<Loan>()
            {
                new Loan()
                {
                    Id = 1,
                    LoanDate = new DateTime(2019, 1, 1),
                    DueDate = new DateTime(2019, 2, 1),
                    ReturnDate = new DateTime(2019, 10, 10),
                },
                new Loan()
                {
                    Id = 2,
                    LoanDate = new DateTime(2019, 1, 1),
                    DueDate = new DateTime(2019, 2, 1),
                    ReturnDate = new DateTime(2019, 10, 10),
                },
            };

            return output;
        }
    }
}
