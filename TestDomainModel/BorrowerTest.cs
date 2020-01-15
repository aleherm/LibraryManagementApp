// <copyright file="BorrowerTest.cs" company="Transilvania University of Brasov">
// Copyright (c) Alexandra Hermeneanu. All rights reserved.
// </copyright>

namespace TestDomainModel
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using DomainModel;
    using NUnit.Framework;

    /// <summary>
    /// The Borrower test class.
    /// </summary>
    [TestFixture]
    public class BorrowerTest
    {
        /// <summary>
        /// Borrower object to test.
        /// </summary>
        private Borrower borrower;

        /// <summary>
        /// The Borrower validation context.
        /// </summary>
        private ValidationContext context;

        /// <summary>
        /// Validation errors returned.
        /// </summary>
        private IList<ValidationResult> validationResults;

        [SetUp]
        public void SetUpBorrower()
        {
            borrower = new Borrower()
            {
                Id = 1,
                FirstName = "Alexandra",
                LastName = "Hermeneanu",
                Email = "ale.herm@email.com",
                Gender = EGenderType.EFemale,
                Address = new Address(),
                Loans = new List<Loan> { new Loan() },
                ReaderFlg = true,
                LibrarianFlg = false,
            };

            context = new ValidationContext(borrower);
            validationResults = new List<ValidationResult>();
        }

        [Test]
        public void FirstNameShouldNotBeEmpty()
        {
            Assert.IsNotEmpty(borrower.FirstName);
        }

        [Test]
        public void LastNameShouldNotBeEmpty()
        {
            Assert.IsNotEmpty(borrower.LastName);
        }

        [Test]
        public void FirstNameShouldNotBeNull()
        {
            borrower.FirstName = null;

            var actual = Validator.TryValidateObject(borrower, context, validationResults, true);

            // Assert
            Assert.IsFalse(actual, "Expected validation to fail.");
            Assert.AreEqual(1, validationResults.Count, "Unexpected number of validation errors.");
            var msg = validationResults[0];
            Assert.AreEqual(ErrorMessages.FirstNameRequired, msg.ErrorMessage);
        }

        [Test]
        public void LastNameShouldNotBeNull()
        {
            borrower.LastName = null;

            var actual = Validator.TryValidateObject(borrower, context, validationResults, true);

            // Assert
            Assert.IsFalse(actual, "Expected validation to fail.");
            Assert.AreEqual(1, validationResults.Count, "Unexpected number of validation errors.");
            var msg = validationResults[0];
            Assert.AreEqual(ErrorMessages.LastNameRequired, msg.ErrorMessage);
        }

        [Test]
        public void EmailShouldNotBeNull()
        {
            borrower.Email = null;

            var actual = Validator.TryValidateObject(borrower, context, validationResults, true);

            // Assert
            Assert.IsFalse(actual, "Expected validation to fail.");
            Assert.AreEqual(1, validationResults.Count, "Unexpected number of validation errors.");
            var msg = validationResults[0];
            Assert.AreEqual(ErrorMessages.EmailRequired, msg.ErrorMessage);
        }

        [Test]
        public void LoanListShouldNotBeNull()
        {
            borrower.Loans = null;

            var actual = Validator.TryValidateObject(borrower, context, validationResults, true);

            // Assert
            Assert.IsFalse(actual, "Expected validation to fail.");
            Assert.AreEqual(1, validationResults.Count, "Unexpected number of validation errors.");
            var msg = validationResults[0];
            Assert.AreEqual(ErrorMessages.LoanRequired, msg.ErrorMessage);
        }

        [Test]
        public void FirstNameShouldNotHaveMoreThan50Chars()
        {
            borrower.FirstName = new string('a', 51);

            var actual = Validator.TryValidateObject(borrower, context, validationResults, true);

            // Assert
            Assert.IsFalse(actual, "Expected validation to fail.");
            Assert.AreEqual(1, validationResults.Count, "Unexpected number of validation errors.");
            var msg = validationResults[0];
            Assert.AreEqual(ErrorMessages.FirstNameRangeLength, msg.ErrorMessage);
        }

        [Test]
        [Sequential]
        public void FirstNameShouldNotHaveNoCharsOutsideRange([Values("x", "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx")] string name)
        {
            borrower.FirstName = name;

            var actual = Validator.TryValidateObject(borrower, context, validationResults, true);

            // Assert
            Assert.IsFalse(actual, "Expected validation to fail.");
            Assert.AreEqual(1, validationResults.Count, "Unexpected number of validation errors.");
            var msg = validationResults[0];
            Assert.AreEqual(ErrorMessages.FirstNameRangeLength, msg.ErrorMessage);
        }

        [Test]
        public void LastNameShouldNotHaveMoreThan50Chars()
        {
            borrower.LastName = new string('x', 51);

            var actual = Validator.TryValidateObject(borrower, context, validationResults, true);

            // Assert
            Assert.IsFalse(actual, "Expected validation to fail.");
            Assert.AreEqual(1, validationResults.Count, "Unexpected number of validation errors.");
            var msg = validationResults[0];
            Assert.AreEqual(ErrorMessages.LastNameRangeLength, msg.ErrorMessage);
        }

        [Test]
        [Sequential]
        public void LastNameShouldNotHaveNoCharsOutsideRange([Values("x", "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx")] string name)
        {
            borrower.LastName = name;

            var actual = Validator.TryValidateObject(borrower, context, validationResults, true);

            // Assert
            Assert.IsFalse(actual, "Expected validation to fail.");
            Assert.AreEqual(1, validationResults.Count, "Unexpected number of validation errors.");
            var msg = validationResults[0];
            Assert.AreEqual(ErrorMessages.LastNameRangeLength, msg.ErrorMessage);
        }

        [Test]
        public void EmailShouldNotBeEmpty()
        {
            borrower.Email = string.Empty;

            var actual = Validator.TryValidateObject(borrower, context, validationResults, true);

            // Assert
            Assert.IsFalse(actual, "Expected validation to fail.");
            Assert.AreEqual(1, validationResults.Count, "Unexpected number of validation errors.");
        }

        [Test]
        public void EmailShouldBeValid()
        {
            var actual = Validator.TryValidateObject(borrower, context, validationResults, true);

            // Assert
            Assert.IsTrue(actual, "Expected validation to pass.");
            Assert.AreEqual(0, validationResults.Count, "Unexpected number of validation errors.");
        }

        [Test]
        public void EmailShouldNotBeValid()
        {
            borrower.Email = "ale.herm";

            var actual = Validator.TryValidateObject(borrower, context, validationResults, true);

            // Assert
            Assert.IsFalse(actual, "Expected validation to fail.");
            Assert.AreEqual(1, validationResults.Count, "Unexpected number of validation errors.");

            var msg = validationResults[0];
            Assert.AreEqual(ErrorMessages.InvalidEmail, msg.ErrorMessage);
        }

        [Test]
        public void DateOfBirthShouldBeValid()
        {
            var actual = Validator.TryValidateObject(borrower, context, validationResults, true);

            // Assert
            Assert.IsTrue(actual, "Expected validation to pass.");
            Assert.AreEqual(0, validationResults.Count, "Unexpected number of validation errors.");
        }

        [Test]
        public void DateOfBirthShouldNotBeValidWithFutureDate()
        {
            borrower.DateOfBirth = new System.DateTime(2050, 10, 10);

            var actual = Validator.TryValidateObject(borrower, context, validationResults, true);

            // Assert
            Assert.IsFalse(actual, "Expected validation to fail.");
            Assert.AreEqual(1, validationResults.Count, "Unexpected number of validation errors.");

            var msg = validationResults[0];
            Assert.AreEqual(1, msg.MemberNames.Where(item => item == "DateOfBirth").Count());
        }

        [Test]
        public void BorrowerCannotBeNonReaderAndNonLibrarian()
        {
            borrower.LibrarianFlg = false;
            borrower.ReaderFlg = false;

            var actual = Validator.TryValidateObject(borrower, context, validationResults, true);

            // Assert
            Assert.IsFalse(actual, "Expected validation to fail.");
            Assert.AreEqual(1, validationResults.Count, "Unexpected number of validation errors.");

            var msg = validationResults[0];
            Assert.AreEqual(2, msg.MemberNames.Where(item => item.Contains("Flg")).Count());
        }

        [Test]
        public void BorrowerShouldBeAtLeastReader()
        {
            borrower.LibrarianFlg = false;

            var actual = Validator.TryValidateObject(borrower, context, validationResults, true);

            // Assert
            Assert.IsTrue(actual, "Expected validation to pass.");
            Assert.AreEqual(0, validationResults.Count, "Unexpected number of validation errors.");
        }
    }
}
