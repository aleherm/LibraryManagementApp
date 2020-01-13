namespace TestDomainModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using DomainModel;
    using NUnit.Framework;

    /// <summary>
    /// The Author test class.
    /// </summary>
    [TestFixture]
    public class AuthorTest
    {
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
                DateOfDeath = new DateTime(2010, 1, 1),
            };

            context = new ValidationContext(author);
            validationResults = new List<ValidationResult>();
        }

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

        [Test]
        [Sequential]
        public void FirstNameShouldNotHaveNoCharsOutsideRange([Values("A", "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx")] string name)
        {
            author.FirstName = name;

            var actual = Validator.TryValidateObject(author, context, validationResults, true);

            // Assert
            Assert.IsFalse(actual, "Expected validation to fail.");
            Assert.AreEqual(1, validationResults.Count, "Unexpected number of validation errors.");
            var msg = validationResults[0];
            Assert.AreEqual(ErrorMessages.FirstNameRangeLength, msg.ErrorMessage);
        }

        [Test]
        public void LastNameShouldNotHaveMoreThan50Chars()
        {
            author.LastName = new string('a', 51);

            var actual = Validator.TryValidateObject(author, context, validationResults, true);

            // Assert
            Assert.IsFalse(actual, "Expected validation to fail.");
            Assert.AreEqual(1, validationResults.Count, "Unexpected number of validation errors.");
            var msg = validationResults[0];
            Assert.AreEqual(ErrorMessages.LastNameRangeLength, msg.ErrorMessage);
        }

        [Test]
        [Sequential]
        public void LastNameShouldNotHaveNoCharsOutsideRange([Values("A", "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx")] string name)
        {
            author.LastName = name;

            var actual = Validator.TryValidateObject(author, context, validationResults, true);

            // Assert
            Assert.IsFalse(actual, "Expected validation to fail.");
            Assert.AreEqual(1, validationResults.Count, "Unexpected number of validation errors.");
            var msg = validationResults[0];
            Assert.AreEqual(ErrorMessages.LastNameRangeLength, msg.ErrorMessage);
        }

        [Test]
        public void DateOfBirthShouldBeValid()
        {
            var actual = Validator.TryValidateObject(author, context, validationResults, true);

            // Assert
            Assert.IsTrue(actual, "Expected validation to pass.");
            Assert.AreEqual(0, validationResults.Count, "Unexpected number of validation errors.");
        }

        [Test]
        public void DateOfBirthShouldNotBeValidWithFutureDate()
        {
            author.DateOfBirth = new DateTime(2050, 10, 10);

            var actual = Validator.TryValidateObject(author, context, validationResults, true);

            // Assert
            Assert.IsFalse(actual, "Expected validation to fail.");
            Assert.AreEqual(1, validationResults.Count, "Unexpected number of validation errors.");
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
            Assert.AreEqual(1, msg.MemberNames.Where(item => item == "DateOfBirth").Count());
        }

        [Test]
        public void DateOfDeathShouldBeValid()
        {
            var actual = Validator.TryValidateObject(author, context, validationResults, true);

            // Assert
            Assert.IsTrue(actual, "Expected validation to pass.");
            Assert.AreEqual(0, validationResults.Count, "Unexpected number of validation errors.");
        }

        [Test]
        public void DateOfDeathShouldNotBeValidWithFutureDate()
        {
            author.DateOfDeath = new System.DateTime(2050, 10, 10);

            var actual = Validator.TryValidateObject(author, context, validationResults, true);

            // Assert
            Assert.IsFalse(actual, "Expected validation to fail.");
            Assert.AreEqual(1, validationResults.Count, "Unexpected number of validation errors.");

            var msg = validationResults[0];
            Assert.AreEqual(ErrorMessages.InvalidDate, msg.ErrorMessage);
            Assert.AreEqual(1, msg.MemberNames.Where(item => item == "DateOfDeath").Count());
        }
    }
}
