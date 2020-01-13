// <copyright file="BorrowerServiceTest.cs" company="Transilvania University of Brasov">
// Copyright (c) Transilvania University of Brasov. Code by Alexandra Hermeneanu. All rights reserved.
// </copyright>

namespace TestServices
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
    using DomainModel;
    using Moq;
    using Newtonsoft.Json;
    using NUnit.Framework;
    using Services;

    /// <summary>
    /// Test class for the BorrowerService.
    /// </summary>
    [SuppressMessage("Microsoft.StyleCop.CSharp.OrderingRules", "SA1101", Justification = "In .NET this is rarely used.")]
    [SuppressMessage("Microsoft.StyleCop.CSharp.OrderingRules", "SA1600", Justification = "Tests are self documented.")]
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
            using (StreamReader r = new StreamReader("external-data.json"))
            {
                var json = r.ReadToEnd();
                var items = JsonConvert.DeserializeObject<List<Threshold>>(json);
                foreach (var item in items)
                {
                    Console.WriteLine("{0} {1}", item.LimitLoanExtension, item.Delta);
                }
            }

            Assert.AreEqual(service.AddNewBorrower(borrower), true);
        }
    }
}
