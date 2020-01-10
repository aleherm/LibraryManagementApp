// <copyright file="BorrowerServiceTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TestServices
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using DomainModel;
    using Moq;
    using NUnit.Framework;
    using Services;

    /// <summary>
    /// Test class for the BorrowerService.
    /// </summary>
    [SuppressMessage("Microsoft.StyleCop.CSharp.OrderingRules", "SA1101", Justification = "In .NET this is rarely used.")]
    [TestFixture]
    public class BorrowerServiceTest
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

        /// <summary>
        /// Test that should pass with valid Borrower object.
        /// </summary>
        [Test]
        public void BorowerShouldBeValid()
        {
            Assert.AreEqual(service.IsValidBorrower(borrower), true);
        }

        /// <summary>
        /// Test that should pass with valid Borrower object.
        /// </summary>
        [Test]
        public void AddBorowerShouldBeSuccessful()
        {
            Assert.AreEqual(service.AddNewBorrower(borrower), true);
        }
    }
}
