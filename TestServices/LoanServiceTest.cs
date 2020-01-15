// <copyright file="ServiceTest.cs" company="Transilvania University of Brasov">
// Copyright (c) Alexandra Hermeneanu. All rights reserved.
// </copyright>

namespace TestServices
{
    using DomainModel;
    using NUnit.Framework;
    using Services;
    using System;

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
    }
}
