using DomainModel;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDomainModel
{
    [TestFixture]
    public class BorrowerTest
    {
        private Borrower borrower;
        [SetUp]
        public void SetUpBorrower()
        {
            borrower = new Borrower()
            {
                Id = 1,
                FirstName = "Alexandra",
                LastName = "Hermeneanu"

            };
        }

        [Test]
        public void FirstNameShouldHaveMoreThan2Characters()
        {
            Assert.GreaterOrEqual(borrower.FirstName.Length, 2);
        }

        [Test]
        public void FirstNameShouldNotHaveLessThan2Characters()
        {
            borrower.FirstName = "Jo";
            Assert.IsFalse(borrower.FirstName.Length > 2);
        }

        [Test]
        public void LastNameShouldHaveMoreThan2Characters()
        {
            Assert.GreaterOrEqual(borrower.LastName.Length, 2);
        }

        [Test]
        public void LastNameShouldNotHaveLessThan2Characters()
        {
            borrower.LastName = "Mo";
            Assert.IsFalse(borrower.LastName.Length > 2);
        }
    }
}
