// <copyright file="BorrowerServiceTest.cs" company="Transilvania University of Brasov">
// Copyright (c) Alexandra Hermeneanu. All rights reserved.
// </copyright>

namespace TestServices
{
    using System;
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
    }
}
