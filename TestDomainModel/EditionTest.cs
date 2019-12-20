using DomainModel;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace TestDomainModel
{
    [TestFixture]
    public class EditionTest
    {
        #region [ Declarations ]

        /// <summary>
        /// Edition object to test.
        /// </summary>
        private Edition edition;

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

            context = new ValidationContext(edition);
            validationResults = new List<ValidationResult>();
        }

        #endregion

        #region [ Required Tests ]

        [TestCase]
        public void PublisherNameShouldNotBeNull()
        {
            edition.Publisher = null;

            bool isValid = Validator.TryValidateObject(edition, context, validationResults);

            Assert.IsFalse(isValid);
        }

        #endregion

        #region [ Year Tests ]

        [Test]
        public void YearShouldNotBeLessOrEqualThatZero([Values(-50, -1, 0)] int year)
        {
            edition.Year = year;

            var actual = Validator.TryValidateObject(edition, context, validationResults, true);

            // Assert
            Assert.IsFalse(actual, "Expected validation to fail.");
            Assert.AreEqual(1, validationResults.Count, "Unexpected number of validation errors.");

            var msg = validationResults[0];
            Assert.AreEqual(ErrorMessages.InvalidYear, msg.ErrorMessage);
            Assert.AreEqual(1, msg.MemberNames.Where(item => item == "Year").Count());
        }

        [Test]
        public void YearShouldNotBeBiggerThanCurrent()
        {
            edition.Year = DateTime.Now.Year + 1;

            var actual = Validator.TryValidateObject(edition, context, validationResults, true);

            // Assert
            Assert.IsFalse(actual, "Expected validation to fail.");
            Assert.AreEqual(1, validationResults.Count, "Unexpected number of validation errors.");

            var msg = validationResults[0];
            Assert.AreEqual(ErrorMessages.InvalidYear, msg.ErrorMessage);
            Assert.AreEqual(1, msg.MemberNames.Where(item => item == "Year").Count());
        }

        #endregion

        #region [ PageNumber Tests ]
        
        [Test]
        public void PageNumberWithinRangeShouldBeValid([Values(5, 100, 4000)] int pages)
        {
            edition.PageNumber = pages;

            var actual = Validator.TryValidateObject(edition, context, validationResults, true);

            // Assert
            Assert.IsTrue(actual, "Expected validation to fail.");
            Assert.AreEqual(0, validationResults.Count, "Unexpected number of validation errors.");
        }

        [Test]
        public void PageNumberShouldNotBeSmallerThan5([Values(-1, 0, 4)] int pages)
        {
            edition.PageNumber = pages;

            var actual = Validator.TryValidateObject(edition, context, validationResults, true);

            // Assert
            Assert.IsFalse(actual, "Expected validation to fail.");
            Assert.AreEqual(1, validationResults.Count, "Unexpected number of validation errors.");
        }

        #endregion

        #region [ Publisher Tests ]

        [Test]
        public void PublisherNameShouldNotHaveLessThan3Characters([Values("x", "xx")] string name)
        {
            edition.Publisher = name;

            var actual = Validator.TryValidateObject(edition, context, validationResults, true);

            // Assert
            Assert.IsFalse(actual, "Expected validation to fail.");
            Assert.AreEqual(1, validationResults.Count, "Unexpected number of validation errors.");
            var msg = validationResults[0];
            Assert.AreEqual(ErrorMessages.PublisherRangeLength, msg.ErrorMessage);
        }

        [Test]
        public void PublisherNameShouldBevalidWithNoCharsWithinRange([Values("Amintiri din copilarie", "Morometii", "XoXo")] string name)
        {
            edition.Publisher = name;

            var actual = Validator.TryValidateObject(edition, context, validationResults, true);

            // Assert
            Assert.IsTrue(actual, "Expected validation to pass.");
            Assert.AreEqual(0, validationResults.Count, "Unexpected number of validation errors.");
        }

        [Test]
        public void PublisherShouldNotHaveMoreThan100Chars()
        {
            edition.Publisher = new string('x', 101);

            var actual = Validator.TryValidateObject(edition, context, validationResults, true);

            // Assert
            Assert.IsFalse(actual, "Expected validation to fail.");
            Assert.AreEqual(1, validationResults.Count, "Unexpected number of validation errors.");
            var msg = validationResults[0];
            Assert.AreEqual(ErrorMessages.PublisherRangeLength, msg.ErrorMessage);
        }

        #endregion

        #region [ NoForLibrary ]

        #endregion

        #region [ NoForLoan ]

        #endregion

        #region [ NoTotal ]

        [TestCase]
        public void NoTotalShouldNotBeSumOfLoanAndLibraryBooksNumber()
        {
            edition.NoForLibrary = 5;
            edition.NoForLoan = 10;
            edition.NoTotal = 15;

            Assert.AreEqual(edition.NoForLibrary + edition.NoForLoan, edition.NoTotal);
        }

        #endregion
    }
}
