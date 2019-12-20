using DomainModel;
using NUnit.Framework;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace TestDomainModel
{
    [TestFixture]
    public class BorrowerTest
    {
        #region [ Declarations ]
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

        #endregion

        #region [ Setup ]

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
                LibrarianFlg = false
            };

            context = new ValidationContext(borrower);
            validationResults = new List<ValidationResult>();
        }

        #endregion

        #region [ Not Empty Tests ]

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

        #endregion

        #region [ Required Tests ]

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

        #endregion

        #region [ FirstName Tests ]

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

        [Test, Sequential]
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

        #endregion

        #region [ LastName Tests ]

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

        [Test, Sequential]
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

        #endregion

        #region [ Email Tests ] 

        [Test]
        public void EmailShouldNotBeEmpty()
        {
            borrower.Email = "";

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

        #endregion

        #region [ DateOfBirth Tests ]

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
            Assert.AreEqual(ErrorMessages.InvalidDate, msg.ErrorMessage);
            Assert.AreEqual(1, msg.MemberNames.Where(item => item == "DateOfBirth").Count());
        }

        #endregion
    }
}
