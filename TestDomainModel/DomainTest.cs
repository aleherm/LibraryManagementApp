// NUnit 3 tests
// See documentation : https://github.com/nunit/docs/wiki/NUnit-Documentation
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
        private Domain domain;

        [SetUp]
        public void DomainSetUp()
        {
            domain = new Domain()
            {
                Id = 2,
                DomainName = "Math",
                ParentDomain = new Domain() { Id = 1, DomainName = "Science", ParentDomain = null},
            };
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

            ValidationContext context = new ValidationContext(domain, serviceProvider: null, items: null);
            IList<ValidationResult> results = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(domain, context, results);
            Assert.IsFalse(isValid);
        }
    }
}
