using DomainModel;
using NUnit.Framework;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
        /// The BOrrower validation context.
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
                ReaderFlg = 1,
                LibrarianFlg = 0
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

        [Test]
        public void ReaderFlagShouldNotBeNull()
        {
            borrower.ReaderFlg = null;

            var actual = Validator.TryValidateObject(borrower, context, validationResults, true);

            // Assert
            Assert.IsFalse(actual, "Expected validation to fail.");
            Assert.AreEqual(1, validationResults.Count, "Unexpected number of validation errors.");
            var msg = validationResults[0];
            Assert.AreEqual(ErrorMessages.ReaderFlagRequired, msg.ErrorMessage);
        }

        [Test]
        public void LibrarianFlagShouldNotBeNull()
        {
            borrower.LibrarianFlg = null;

            var actual = Validator.TryValidateObject(borrower, context, validationResults, true);

            // Assert
            Assert.IsFalse(actual, "Expected validation to fail.");
            Assert.AreEqual(1, validationResults.Count, "Unexpected number of validation errors.");
            var msg = validationResults[0];
            Assert.AreEqual(ErrorMessages.LibrarianFlagRequired, msg.ErrorMessage);
        }

        #endregion

        #region [ First Name Tests ]

        #endregion
    }
}
