using DomainModel;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TestDomainModel
{
    [TestFixture]
    public class EditionTest
    {
        private Edition edition;
        private ValidationContext context;
        private IList<ValidationResult> results;

        [SetUp]
        public void SetUpEdition()
        {
            edition = new Edition()
            {
                PageNumber = 100,
                Year = 2019,
                BookType = EBookType.EHardCover,
                Publisher = "Humanitas",
                NoTotal = 10,
                NoForLibrary = 2,
                NoForLoan = 8
            };

            context = new ValidationContext(edition, serviceProvider: null, items: null);
            results = new List<ValidationResult>();
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
        public void PublisherNameShouldNotBeNull()
        {
            edition.Publisher = null;

            bool isValid = Validator.TryValidateObject(edition, context, results);

            Assert.IsFalse(isValid);
        }

        [TestCase]
        public void NoTotalShouldNotBeSumOfLoanAndLibraryBooksNumber()
        {
            edition.NoForLibrary = 5;
            edition.NoForLoan = 10;
            edition.NoTotal = 15;

            Assert.AreEqual(edition.NoForLibrary + edition.NoForLoan, edition.NoTotal);
        }
    }
}
