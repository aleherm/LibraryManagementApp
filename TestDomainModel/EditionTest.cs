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
    public class EditionTest
    {
        private Edition edition;
        
        [SetUp]
        public void SetUpEdition()
        {
            edition = new Edition()
            {
                PageNumber = 100,
                Year = 2019,
                BookType = EBookType.EHardCover,
                Publisher = "aa",
                NoTotal = 10,
                NoForLibrary = 2,
                NoForLoan = 8
            };
        }

        [Test]
        public void PageNumberShouldBeGreaterThatZero()
        {
            Assert.Greater(edition.PageNumber, 0);
        }

        [Test]
        public void PageNumberShouldNotBeLessOrEqualThatZero()
        {
            edition.PageNumber = -1;
            Assert.IsFalse(edition.PageNumber >= 0);
        }

        [Test]
        public void YearShouldBeLessOrEqualThanCurrentYear()
        {
            Assert.LessOrEqual(edition.Year, DateTime.Now.Year);
        }

        [Test]
        public void YearShouldNotBeLessOrEqualThatZero()
        {
            Assert.Greater(edition.Year, 0);
        }

        [TestCase]
        public void PublisherNameShouldHaveAtLeast5Characters()
        {
            edition.Publisher = "Humanitas";
            Assert.Greater(edition.Publisher.Length, 5);
        }

        [TestCase]
        public void PublisherNameShouldNotHaveLessThan5Characters()
        {
            Assert.Less(edition.Publisher.Length, 5);
        }
    }
}
