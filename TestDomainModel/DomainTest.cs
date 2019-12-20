using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DomainModel;
using NUnit.Framework;

namespace TestDomainModel
{
    [TestFixture]
    public class DomainTest
    {
        #region [ Declarations ]

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

        #endregion

        #region [ Setup ]

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
                ParentDomain = new Domain() { Id = 1, DomainName = "Science", ParentDomain = null},
            };

            context = new ValidationContext(domain);
            validationResults = new List<ValidationResult>();
        }

        #endregion
        
        #region [ Not Empty Tests ]

        [Test]
        public void DomainNameShouldNotBeEmpty()
        {
            Assert.IsNotEmpty(domain.DomainName);
        }

        #endregion

        #region [ Required Tests ]

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

        #endregion

        #region [ DomainName Tests ]

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

        #endregion
    }
}
