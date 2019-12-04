// NUnit 3 tests
// See documentation : https://github.com/nunit/docs/wiki/NUnit-Documentation
using System.Collections;
using System.Collections.Generic;
using DomainModel;
using NUnit.Framework;

namespace TestDomainModel
{
    [TestFixture]
    public class DomainTest
    {
        [Test]
        public void DomainNameShouldHaveAtLeast3Characters()
        {
            string name = "All";
            Domain domain = new Domain();
            domain.DomainName = name;
            Assert.AreEqual(name, domain.DomainName);
        }

        [Test]
        public void DomainNameShouldNotHaveLessThan3Characters()
        {
            string name = "A";
            Domain domain = new Domain();
            domain.DomainName = name;
            bool condition = name.Length >= 3;
            Assert.IsFalse(condition, "The Domain Name should have at least 3 characters");
        }
    }
}
