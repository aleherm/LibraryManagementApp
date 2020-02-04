// <copyright file="DomainTest.cs" company="Transilvania University of Brasov">
// Copyright (c) Alexandra Hermeneanu. All rights reserved.
// </copyright>

namespace TestDomainModel
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using DomainModel;
    using NUnit.Framework;

    /// <summary>
    /// The Domain test class.
    /// </summary>
    [TestFixture]
    public class DomainTest
    {
        /// <summary>
        /// Domain object to test.
        /// </summary>
        private Domain domain;

        /// <summary>
        /// The Borrower validation context.
        /// </summary>
        private ValidationContext context;

        /// <summary>
        /// Validation errors returned.
        /// </summary>
        private IList<ValidationResult> validationResults;

        /// <summary>
        /// Sets up valid properties for the object to be tested.
        /// </summary>
        [SetUp]
        public void DomainSetUp()
        {
            domain = new Domain()
            {
                Id = 2,
                DomainName = "Mathematics",
                ParentDomain = new Domain()
                {
                    Id = 1,
                    DomainName = "Science",
                    ParentDomain = null
                },
            };

            context = new ValidationContext(domain);
            validationResults = new List<ValidationResult>();
        }

        [Test]
        public void DomainNameShouldNotBeEmpty()
        {
            Assert.IsNotEmpty(domain.DomainName);
        }

        [Test]
        public void DomainNameShouldNotBeNull()
        {
            domain.DomainName = null;

            var actual = Validator.TryValidateObject(domain, context, validationResults, true);

            // Assert
            Assert.IsFalse(actual, "Expected validation to fail.");
            Assert.AreEqual(1, validationResults.Count, "Unexpected number of validation errors.");
            var msg = validationResults[0];
            Assert.AreEqual(ErrorMessages.DomainNameRequired, msg.ErrorMessage);
        }

        [Test]
        public void SubdomainsShouldNotBeNull()
        {
            domain.Subdomains = null;

            var actual = Validator.TryValidateObject(domain, context, validationResults, true);

            // Assert
            Assert.IsFalse(actual, "Expected validation to fail.");
            Assert.AreEqual(1, validationResults.Count, "Unexpected number of validation errors.");
            var msg = validationResults[0];
            Assert.AreEqual(ErrorMessages.SubdomainRequired, msg.ErrorMessage);
        }

        [Test]
        public void DomainNameShouldNotHaveMoreThan100Chars()
        {
            domain.DomainName = new string('a', 101);

            var actual = Validator.TryValidateObject(domain, context, validationResults, true);

            // Assert
            Assert.IsFalse(actual, "Expected validation to fail.");
            Assert.AreEqual(1, validationResults.Count, "Unexpected number of validation errors.");
            var msg = validationResults[0];
            Assert.AreEqual(ErrorMessages.DomainNameRangeLength, msg.ErrorMessage);
        }

        [Test]
        public void DomainNameShouldNotHaveLessThan5Chars()
        {
            domain.DomainName = "Math";

            var actual = Validator.TryValidateObject(domain, context, validationResults, true);

            // Assert
            Assert.IsFalse(actual, "Expected validation to fail.");
            Assert.AreEqual(1, validationResults.Count, "Unexpected number of validation errors.");
            var msg = validationResults[0];
            Assert.AreEqual(ErrorMessages.DomainNameRangeLength, msg.ErrorMessage);
        }

        [Test]
        public void DomainShouldBeValid()
        {
            Domain actual = new Domain("Domain", new Domain("Parent", null, new List<Domain>(), null), new List<Domain>(), null);

            context = new ValidationContext(actual);
            var isValid = Validator.TryValidateObject(actual, context, validationResults, true);

            // Assert
            Assert.IsTrue(isValid, "Expected validation to pass.");
            Assert.AreEqual(0, validationResults.Count, "Unexpected number of validation errors.");
        }

        [Test]
        public void TestValidToString()
        {
            Assert.AreEqual("Mathematics | Science |   ", domain.ToString());
        }

        [Test]
        public void TestInvalidToString()
        {
            Assert.AreEqual("Mathematics | Science |   ", domain.ToString());
        }

        [Test]
        public void EqualsShouldBeTrue()
        {
            Domain actual = new Domain()
            {
                Id = 2,
                DomainName = "Mathematics",
                ParentDomain = new Domain()
                {
                    Id = 1,
                    DomainName = "Science",
                    ParentDomain = null
                },
            };

            Assert.IsTrue(actual.Equals(domain));
        }

        [Test]
        public void EqualsShouldBeFalse()
        {
            Domain expected = new Domain()
            {
                Id = 2,
                DomainName = "Science Fiction",
                ParentDomain = new Domain()
                {
                    Id = 1,
                    DomainName = "Fiction",
                    ParentDomain = null
                },
            };

            Assert.IsFalse(expected.Equals(domain));
        }
    }
}
