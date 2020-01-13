// <copyright file="ServiceTest.cs" company="Transilvania University of Brasov">
// Copyright (c) Transilvania University of Brasov. Code by Alexandra Hermeneanu. All rights reserved.
// </copyright>

namespace TestServices
{
    using System.Collections.Generic;
    using System.IO;
    using DomainModel;
    using Newtonsoft.Json;
    using NUnit.Framework;

    [TestFixture]
    public abstract class ServiceTest
    { 
        private Threshold threshold;

        [SetUp]
        public void BorrowerServiceSetUp()
        {
            string solutionDirectory = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(TestContext.CurrentContext.TestDirectory)));
            threshold = GetThresholdFromJSON(solutionDirectory);
        }

        [Test]
        public abstract void EntityShouldBeValid();

        [Test]
        public abstract void EntityShouldNotBeValid();

        [Test]
        public abstract void AddNewValidEntityShouldBeSuccessful();

        [Test]
        public abstract void AddNewInvalidEntityShouldFail();

        /// <summary>
        /// Gets the threshold data needed for validation from the external JSON file.
        /// </summary>
        /// <param name="path"></param>
        /// <returns>A Threshold object.</returns>
        protected Threshold GetThresholdFromJSON(string path)
        {
            StreamReader reader = new StreamReader(path + "\\external-data.json");
            string json = reader.ReadToEnd();
            List<Threshold> items = JsonConvert.DeserializeObject<List<Threshold>>(json);
            return items[0];
        }
    }
}
