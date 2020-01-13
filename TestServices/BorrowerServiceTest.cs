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
        /// The threshold item needed to validate loan data.
        /// </summary>
        private Threshold threshold;

        /// <summary>
        /// The setup of the BorrowerService object to be tested.
        /// </summary>
        [SetUp]
        public void BorrowerServiceSetUp()
        {
            service = new BorrowerService();
            Address address = new Address("Brasov", "Octavian", 10);
            borrower = new Borrower("Alexandra", "Hermeneanu", "ale@email.com", new DateTime(1999, 10, 10), address, true, false);

            string solutionDirectory = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(TestContext.CurrentContext.TestDirectory)));
            threshold = GetThresholdFromJSON(solutionDirectory);
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

        /// <summary>
        /// Gets the threshold data needed for validation from the external JSON file.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private Threshold GetThresholdFromJSON(string path)
        {
            StreamReader reader = new StreamReader(path + "\\external-data.json");
            string json = reader.ReadToEnd();
            List<Threshold> items = JsonConvert.DeserializeObject<List<Threshold>>(json);
            return items[0];
        }
    }
}
