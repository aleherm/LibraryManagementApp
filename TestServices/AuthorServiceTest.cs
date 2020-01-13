// <copyright file="AuthorServiceTest.cs" company="Transilvania University of Brasov">
// Copyright (c) Transilvania University of Brasov. Code by Alexandra Hermeneanu. All rights reserved.
// </copyright>

namespace TestServices
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using DomainModel;
    using Moq;
    using Newtonsoft.Json;
    using NUnit.Framework;
    using Services;

    [TestFixture]
    public class AuthorServiceTest
    {
        /// <summary>
        /// The service instance to be tested.
        /// </summary>
        private AuthorService service;

        /// <summary>
        /// The Author entity based on which the tests will run.
        /// </summary>
        private Author Author;

        /// <summary>
        /// The threshold item needed to validate loan data.
        /// </summary>
        private Threshold threshold;

        /// <summary>
        /// The setup of the AuthorService object to be tested.
        /// </summary>
        [SetUp]
        public void AuthorServiceSetUp()
        {
            service = new AuthorService();
            Author = new Author("Alexandra", "Hermeneanu", "Romana", new DateTime(1997, 07, 02), null);

            string solutionDirectory = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(TestContext.CurrentContext.TestDirectory)));
            threshold = GetThresholdFromJSON(solutionDirectory);
        }

        /// <summary>
        /// Test that should pass with valid Author object.
        /// </summary>
        [Test]
        public void BorowerShouldBeValid()
        {
            Assert.AreEqual(service.IsValidAuthor(Author), true);
        }

        /// <summary>
        /// Test that should pass with not valid Author object.
        /// </summary>
        [Test]
        public void BorowerShouldNotBeValid()
        {
            Assert.AreEqual(service.IsValidAuthor(Author), true);
        }

        /// <summary>
        /// Test that should pass with valid Author object.
        /// </summary>
        [Test]
        public void AddBorowerShouldBeSuccessful()
        {
            Assert.AreEqual(service.AddNewAuthor(Author), true);
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
