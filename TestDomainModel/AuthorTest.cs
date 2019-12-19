using DomainModel;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TestDomainModel
{
    [TestFixture]
    public class AuthorTest
    {
        #region [ Declarations ]

        /// <summary>
        /// The Author object to be tested.
        /// </summary>
        private Author author;

        /// <summary>
        /// The Author validation context.
        /// </summary>
        private ValidationContext context;

        /// <summary>
        /// Validation errors returned for the Author object.
        /// </summary>
        private IList<ValidationResult> validationResults;

        #endregion

        #region [ Setup ]

        /// <summary>
        /// The setup of the Author object to be tested.
        /// </summary>
        [SetUp]
        public void AuthorSetUp()
        {
            author = new Author()
            {
                FirstName = "John",
                LastName = "Smith",
                Language = "English",
                DateOfBirth = new DateTime(1989, 10, 10),
                DateOfDeath = new DateTime(2010, 1, 1)
            };

            context = new ValidationContext(author);
            validationResults = new List<ValidationResult>();
        }

        #endregion

        #region [ Required Tests ]

        [Test]
        public void FirstNameShouldNotBeNull()
        {
            author.FirstName = null;

            var actual = Validator.TryValidateObject(author, context, validationResults, true);

            // Assert
            Assert.IsFalse(actual, "Expected validation to fail.");
            Assert.AreEqual(1, validationResults.Count, "Unexpected number of validation errors.");
            var msg = validationResults[0];
            Assert.AreEqual(ErrorMessages.FirstNameRequired, msg.ErrorMessage);
        }

        [Test]
        public void LastNameShouldNotBeNull()
        {
            author.LastName = null;

            var actual = Validator.TryValidateObject(author, context, validationResults, true);

            // Assert
            Assert.IsFalse(actual, "Expected validation to fail.");
            Assert.AreEqual(1, validationResults.Count, "Unexpected number of validation errors.");
            var msg = validationResults[0];
            Assert.AreEqual(ErrorMessages.LastNameRequired, msg.ErrorMessage);
        }

        [Test]
        public void LanguageShouldNotBeNull()
        {
            author.Language = null;

            var actual = Validator.TryValidateObject(author, context, validationResults, true);

            // Assert
            Assert.IsFalse(actual, "Expected validation to fail.");
            Assert.AreEqual(1, validationResults.Count, "Unexpected number of validation errors.");
            var msg = validationResults[0];
            Assert.AreEqual(ErrorMessages.LanguageRequired, msg.ErrorMessage);
        }

        #endregion

        #region [ FirstName Tests ]

        [Test]
        public void FirstNameShouldNotHaveMoreThan50Chars()
        {
            author.FirstName = new string('a', 51);

            var actual = Validator.TryValidateObject(author, context, validationResults, true);

            // Assert
            Assert.IsFalse(actual, "Expected validation to fail.");
            Assert.AreEqual(1, validationResults.Count, "Unexpected number of validation errors.");
            var msg = validationResults[0];
            Assert.AreEqual(ErrorMessages.FirstNameRangeLength, msg.ErrorMessage);
        }

        [Test, Sequential]
        public void FirstNameShouldNotHaveNoCharsOutsideRange([Values("A", "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa")] string name)
        {
            author.FirstName = name;

            var actual = Validator.TryValidateObject(author, context, validationResults, true);

            // Assert
            Assert.IsFalse(actual, "Expected validation to fail.");
            Assert.AreEqual(1, validationResults.Count, "Unexpected number of validation errors.");
            var msg = validationResults[0];
            Assert.AreEqual(ErrorMessages.FirstNameRangeLength, msg.ErrorMessage);
        }

        #endregion

        #region [ DateOfBirth Tests ]

        [Test]
        public void DateOfBirthShouldBeValid()
        {
            var actual = Validator.TryValidateObject(author, context, validationResults, true);

            // Assert
            Assert.IsTrue(actual, "Expected validation to pass.");
            Assert.AreEqual(0, validationResults.Count, "Unexpected number of validation errors.");
            var msg = validationResults[0];
        }

        [Test]
        public void DateOfBirthShouldNotBeBiggerThanDateOfDeath()
        {
            author.DateOfBirth = new DateTime(2019, 10, 10);
            author.DateOfDeath = new DateTime(2010, 10, 10);

            var actual = Validator.TryValidateObject(author, context, validationResults, true);

            // Assert
            Assert.IsFalse(actual, "Expected validation to fail.");
            Assert.AreEqual(1, validationResults.Count, "Unexpected number of validation errors.");
            var msg = validationResults[0];
            Assert.AreEqual(ErrorMessages.InvalidDate, msg.ErrorMessage);

            foreach (string member in msg.MemberNames)
            {
                Assert.AreEqual("DateOfBirth", member, "Expected DateOfBirth to be invalid related to DateOfDeath.");
            }
        }

        #endregion

        #region [ DateOfBirth Tests ]

        #endregion
    }
}
