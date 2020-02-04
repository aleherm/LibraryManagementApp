// <copyright file="LoanTest.cs" company="Transilvania University of Brasov">
// Copyright (c) Alexandra Hermeneanu. All rights reserved.
// </copyright>

namespace TestDomainModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using DomainModel;
    using NUnit.Framework;

    /// <summary>
    /// Tests the Loan entity.
    /// </summary>
    [TestFixture]
    public class LoanTest
    {
        /// <summary>
        /// Loan object to test.
        /// </summary>
        private Loan loan;

        /// <summary>
        /// The Loan validation context.
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
        public void LoanSetup()
        {
            loan = new Loan()
            {
                Id = 1,
                LoanDate = new DateTime(2019, 1, 1),
                DueDate = new DateTime(2019, 2, 1),
                ReturnDate = new DateTime(2019, 10, 10),
            };

            context = new ValidationContext(loan);
            validationResults = new List<ValidationResult>();
        }

        [Test]
        public void BorrowedEditionsListShouldNotBeNull()
        {
            loan.BorrowedEditions = null;

            var actual = Validator.TryValidateObject(loan, context, validationResults, true);

            // Assert
            Assert.IsFalse(actual, "Expected validation to fail.");
            Assert.AreEqual(1, validationResults.Count, "Unexpected number of validation errors.");
        }

        [Test]
        public void LoanDateShouldNotBeNull()
        {
            loan.LoanDate = null;

            var actual = Validator.TryValidateObject(loan, context, validationResults, true);

            // Assert
            Assert.IsFalse(actual, "Expected validation to fail.");
            Assert.AreEqual(1, validationResults.Count, "Unexpected number of validation errors.");
        }

        [Test]
        public void DueDateShouldNotBeNull()
        {
            loan.DueDate = null;

            var actual = Validator.TryValidateObject(loan, context, validationResults, true);

            // Assert
            Assert.IsFalse(actual, "Expected validation to fail.");
            Assert.AreEqual(1, validationResults.Count, "Unexpected number of validation errors.");
        }

        [Test]
        public void LoanDateShouldNotBeValidWithFutureDate()
        {
            loan.ReturnDate = new DateTime(2019, 10, 10);
            loan.ReturnDate = DateTime.Now;
            loan.LoanDate = DateTime.Now.AddDays(1);

            var actual = Validator.TryValidateObject(loan, context, validationResults, true);

            // Assert
            Assert.IsFalse(actual, "Expected validation to fail.");
            Assert.AreEqual(1, validationResults.Count, "Unexpected number of validation errors.");

            var msg = validationResults[0];
            Assert.AreEqual(1, msg.MemberNames.Where(item => item == "LoanDate").Count());
        }

        [Test]
        public void DueDateShouldNotBeValidWithFutureDate()
        {
            loan.DueDate = DateTime.Now.AddDays(1);

            var actual = Validator.TryValidateObject(loan, context, validationResults, true);

            // Assert
            Assert.IsFalse(actual, "Expected validation to fail.");
            Assert.AreEqual(1, validationResults.Count, "Unexpected number of validation errors.");

            var msg = validationResults[0];
            Assert.AreEqual(1, msg.MemberNames.Where(item => item == "DueDate").Count());
        }

        [Test]
        public void ReturnDateShouldNotBeValidWithFutureDate()
        {
            loan.ReturnDate = DateTime.Now.AddDays(1);

            var actual = Validator.TryValidateObject(loan, context, validationResults, true);

            // Assert
            Assert.IsFalse(actual, "Expected validation to fail.");
            Assert.AreEqual(1, validationResults.Count, "Unexpected number of validation errors.");

            var msg = validationResults[0];
            Assert.AreEqual(1, msg.MemberNames.Where(item => item == "ReturnDate").Count());
        }

        [Test]
        public void LoanDateShouldNotBeAfterReturnDate()
        {
            loan.LoanDate = DateTime.Now;

            var actual = Validator.TryValidateObject(loan, context, validationResults, true);

            // Assert
            Assert.IsFalse(actual, "Expected validation to fail.");
            Assert.AreEqual(1, validationResults.Count, "Unexpected number of validation errors.");

            var msg = validationResults[0];
            Assert.AreEqual(1, msg.MemberNames.Where(item => item == "ReturnDate").Count());
        }

        [Test]
        public void TestToString()
        {
            string expected = "loan: 01/01/2019 | due: 01/02/2019 | return: 10/10/2019 ";
            Assert.AreEqual(expected, loan.ToString());
        }

        [Test]
        public void LoanShouldBeValid()
        {
            Loan actual = new Loan(new DateTime(2010, 10, 10), new DateTime(2011, 10, 10), new DateTime(2010, 10, 10), new List<Edition>());

            context = new ValidationContext(actual);
            var isValid = Validator.TryValidateObject(actual, context, validationResults, true);

            // Assert
            Assert.IsTrue(isValid, "Expected validation to pass.");
            Assert.AreEqual(0, validationResults.Count, "Unexpected number of validation errors.");
        }

        [Test]
        public void EqualsShouldBeTrue()
        {
            Loan actual = new Loan()
            {
                Id = 1,
                LoanDate = new DateTime(2019, 1, 1),
                DueDate = new DateTime(2019, 2, 1),
                ReturnDate = new DateTime(2019, 10, 10),
            };

            Assert.IsTrue(actual.Equals(loan));
        }

        [Test]
        public void EqualsShouldNotBeTrue()
        {
            Loan actual = new Loan()
            {
                Id = 2,
                LoanDate = new DateTime(2019, 1, 10),
                DueDate = new DateTime(2019, 2, 20),
                ReturnDate = new DateTime(2019, 2, 10),
            };

            Assert.IsFalse(actual.Equals(loan));
        }
    }
}
