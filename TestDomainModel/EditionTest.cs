// <copyright file="EditionTest.cs" company="Transilvania University of Brasov">
// Copyright (c) Alexandra Hermeneanu. All rights reserved.
// </copyright>

namespace TestDomainModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using DomainModel;
    using NUnit.Framework;

    /// <summary>
    /// Tests the Edition entity.
    /// </summary>
    [TestFixture]
    public class EditionTest
    {
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
                NoForLoan = 8,
            };

            context = new ValidationContext(edition);
            validationResults = new List<ValidationResult>();
        }

        /// <summary>
        /// Tests the PublisherName to be null.
        /// </summary>
        [TestCase]
        public void PublisherNameShouldNotBeNull()
        {
            edition.Publisher = null;

            bool isValid = Validator.TryValidateObject(edition, context, validationResults);

            Assert.IsFalse(isValid);
        }
        
        [Test]
        public void LoanListShouldNotBeNull()
        {
            edition.Loans = null;

            var actual = Validator.TryValidateObject(edition, context, validationResults, true);

            // Assert
            Assert.IsFalse(actual, "Expected validation to fail.");
            Assert.AreEqual(1, validationResults.Count, "Unexpected number of validation errors.");
            var msg = validationResults[0];
            Assert.AreEqual(ErrorMessages.LoanRequired, msg.ErrorMessage);
        }

        /// <summary>
        /// Tests the Year to be negative or zero.
        /// </summary>
        /// <param name="year">The year of the book Edition.</param>
        [Test]
        public void YearShouldNotBeNegativeOrZero([Values(-50, -1, 0)] int year)
        {
            edition.Year = year;

            var actual = Validator.TryValidateObject(edition, context, validationResults, true);

            // Assert
            Assert.IsFalse(actual, "Expected validation to fail.");
            Assert.AreEqual(1, validationResults.Count, "Unexpected number of validation errors.");

            var msg = validationResults[0];
            Assert.AreEqual(ErrorMessages.InvalidNumber, msg.ErrorMessage);
            Assert.AreEqual(1, msg.MemberNames.Where(item => item == "Year").Count());
        }

        /// <summary>
        /// YearShouldNotBeBiggerThanCurrent.
        /// </summary>
        [Test]
        public void YearShouldNotBeBiggerThanCurrent()
        {
            edition.Year = DateTime.Now.Year + 1;

            var actual = Validator.TryValidateObject(edition, context, validationResults, true);

            // Assert
            Assert.IsFalse(actual, "Expected validation to fail.");
            Assert.AreEqual(1, validationResults.Count, "Unexpected number of validation errors.");

            var msg = validationResults[0];
            Assert.AreEqual(ErrorMessages.InvalidNumber, msg.ErrorMessage);
            Assert.AreEqual(1, msg.MemberNames.Where(item => item == "Year").Count());
        }

        /// <summary>
        /// PageNumberWithinRangeShouldBeValid.
        /// </summary>
        /// <param name="pages">The page number.</param>
        [Test]
        public void PageNumberWithinRangeShouldBeValid([Values(5, 100, 4000)] int pages)
        {
            edition.PageNumber = pages;

            var actual = Validator.TryValidateObject(edition, context, validationResults, true);

            // Assert
            Assert.IsTrue(actual, "Expected validation to fail.");
            Assert.AreEqual(0, validationResults.Count, "Unexpected number of validation errors.");
        }

        /// <summary>
        /// PageNumberShouldNotBeSmallerThan5.
        /// </summary>
        /// <param name="pages">The page number.</param>
        [Test]
        public void PageNumberShouldNotBeSmallerThan5([Values(-1, 0, 4)] int pages)
        {
            edition.PageNumber = pages;

            var actual = Validator.TryValidateObject(edition, context, validationResults, true);

            // Assert
            Assert.IsFalse(actual, "Expected validation to fail.");
            Assert.AreEqual(1, validationResults.Count, "Unexpected number of validation errors.");
        }

        /// <summary>
        /// PublisherNameShouldNotHaveLessThan3Characters.
        /// </summary>
        /// <param name="name">The publisher name.</param>
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

        /// <summary>
        /// PublisherNameShouldBevalidWithNoCharsWithinRange.
        /// </summary>
        /// <param name="name">The publisher name.</param>
        [Test]
        public void PublisherNameShouldBeValidWithNoCharsWithinRange([Values("Amintiri din copilarie", "Morometii", "XoXo")] string name)
        {
            edition.Publisher = name;

            var actual = Validator.TryValidateObject(edition, context, validationResults, true);

            // Assert
            Assert.IsTrue(actual, "Expected validation to pass.");
            Assert.AreEqual(0, validationResults.Count, "Unexpected number of validation errors.");
        }

        /// <summary>
        /// PublisherShouldNotHaveMoreThan100Chars.
        /// </summary>
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

        /// <summary>
        /// NoForLibraryShouldBeBeValidWithPositiveValue.
        /// </summary>
        [Test]
        public void NoForLibraryShouldBeBeValidWithPositiveValue()
        {
            edition.NoForLibrary = 1;

            var actual = Validator.TryValidateObject(edition, context, validationResults, true);

            // Assert
            Assert.IsTrue(actual, "Expected validation to pass.");
            Assert.AreEqual(0, validationResults.Count, "Unexpected number of validation errors.");
        }

        /// <summary>
        /// NoForLibraryShouldNotBeNegative.
        /// </summary>
        [Test]
        public void NoForLibraryShouldNotBeNegative()
        {
            edition.NoForLibrary = -5;

            var actual = Validator.TryValidateObject(edition, context, validationResults, true);

            // Assert
            Assert.IsFalse(actual, "Expected validation to fail.");
            Assert.AreEqual(1, validationResults.Count, "Unexpected number of validation errors.");

            var msg = validationResults[0];
            Assert.AreEqual(ErrorMessages.LibraryBooksRangeNumber, msg.ErrorMessage);
            Assert.AreEqual(1, msg.MemberNames.Where(item => item == "NoForLibrary").Count());
        }

        /// <summary>
        /// NoForLoanShouldBeValidWithPositiveValue.
        /// </summary>
        [Test]
        public void NoForLoanShouldBeValidWithPositiveValue()
        {
            edition.NoForLoan = 1;

            var actual = Validator.TryValidateObject(edition, context, validationResults, true);

            // Assert
            Assert.IsTrue(actual, "Expected validation to pass.");
            Assert.AreEqual(0, validationResults.Count, "Unexpected number of validation errors.");
        }

        /// <summary>
        /// NoForLoanShouldNotBeNegative.
        /// </summary>
        [Test]
        public void NoForLoanShouldNotBeNegative()
        {
            edition.NoForLoan = -5;

            var actual = Validator.TryValidateObject(edition, context, validationResults, true);

            // Assert
            Assert.IsFalse(actual, "Expected validation to fail.");
            Assert.AreEqual(1, validationResults.Count, "Unexpected number of validation errors.");

            var msg = validationResults[0];
            Assert.AreEqual(ErrorMessages.LoanBooksRangeNumber, msg.ErrorMessage);
            Assert.AreEqual(1, msg.MemberNames.Where(item => item == "NoForLoan").Count());
        }

        /// <summary>
        /// NoTotalShouldBeValidWithPositiveValue.
        /// </summary>
        [Test]
        public void NoTotalShouldBeValidWithPositiveValue()
        {
            edition.NoTotal = 11;

            var actual = Validator.TryValidateObject(edition, context, validationResults, true);

            // Assert
            Assert.IsTrue(actual, "Expected validation to pass.");
            Assert.AreEqual(0, validationResults.Count, "Unexpected number of validation errors.");
        }

        /// <summary>
        /// NoTotalShouldNotBeNegative.
        /// </summary>
        [Test]
        public void NoTotalShouldNotBeNegative()
        {
            edition.NoTotal = -5;

            var actual = Validator.TryValidateObject(edition, context, validationResults, true);

            // Assert
            Assert.IsFalse(actual, "Expected validation to fail.");
            Assert.AreEqual(1, validationResults.Count, "Unexpected number of validation errors.");
        }

        /// <summary>
        /// NoTotalShouldNotBeSumOfLoanAndLibraryBooksNumber.
        /// </summary>
        /// <param name="noLib">The book number for library.</param>
        /// <param name="noLoan">The book number for loan.</param>
        /// <param name="noTotal">The total number of books.</param>
        [Test]
        [Sequential]
        public void NoTotalShouldNotBeSumOfLoanAndLibraryBooksNumber([Values(2, 5, 10)] int noLib, [Values(0, 4, 11)] int noLoan, [Values(2, 9, 21)] int noTotal)
        {
            edition.NoForLibrary = noLib;
            edition.NoForLoan = noLoan;
            edition.NoTotal = noTotal;

            Assert.AreEqual(edition.NoForLibrary + edition.NoForLoan, edition.NoTotal);
        }
    }
}
