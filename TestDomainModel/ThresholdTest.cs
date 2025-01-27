﻿// <copyright file="ThresholdTest.cs" company="Transilvania University of Brasov">
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

    [TestFixture]
    public class ThresholdTest
    {
        /// <summary>
        /// Threshold object to test.
        /// </summary>
        private Threshold threshold;

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
            threshold = new Threshold(2, 10, 2, 2, 2, 2, 2, 2, 2);

            context = new ValidationContext(threshold);
            validationResults = new List<ValidationResult>();
        }

        [Test]
        public void MaxDomainsShouldNotBeNegative()
        {
            threshold.MaxDomains = -1;
            var actual = Validator.TryValidateObject(threshold, context, validationResults, true);

            // Assert
            Assert.IsFalse(actual, "Expected validation to fail.");
            Assert.AreEqual(1, validationResults.Count, "Unexpected number of validation errors.");
        }

        [Test]
        public void MaxDomainsShouldBeValidWithPositiveValue()
        {
            var actual = Validator.TryValidateObject(threshold, context, validationResults, true);

            // Assert
            Assert.IsTrue(actual, "Expected validation to pass.");
            Assert.AreEqual(0, validationResults.Count, "Unexpected number of validation errors.");
        }

        [Test]
        public void MaxLoansShouldNotBeNegative()
        {
            threshold.MaxLoans = -1;
            var actual = Validator.TryValidateObject(threshold, context, validationResults, true);

            // Assert
            Assert.IsFalse(actual, "Expected validation to fail.");
            Assert.AreEqual(1, validationResults.Count, "Unexpected number of validation errors.");
        }

        [Test]
        public void MaxLoansShouldBeValidWithPositiveValue()
        {
            var actual = Validator.TryValidateObject(threshold, context, validationResults, true);

            // Assert
            Assert.IsTrue(actual, "Expected validation to pass.");
            Assert.AreEqual(0, validationResults.Count, "Unexpected number of validation errors.");
        }

        [Test]
        public void MaxBooksShouldNotBeNegative()
        {
            threshold.MaxBooks = -1;
            var actual = Validator.TryValidateObject(threshold, context, validationResults, true);

            // Assert
            Assert.IsFalse(actual, "Expected validation to fail.");
            Assert.AreEqual(1, validationResults.Count, "Unexpected number of validation errors.");
        }

        [Test]
        public void MaxBooksShouldBeValidWithPositiveValue()
        {
            var actual = Validator.TryValidateObject(threshold, context, validationResults, true);

            // Assert
            Assert.IsTrue(actual, "Expected validation to pass.");
            Assert.AreEqual(0, validationResults.Count, "Unexpected number of validation errors.");
        }

        [Test]
        public void PeriodShouldNotBeNegative()
        {
            threshold.Period = -1;
            var actual = Validator.TryValidateObject(threshold, context, validationResults, true);

            // Assert
            Assert.IsFalse(actual, "Expected validation to fail.");
            Assert.AreEqual(1, validationResults.Count, "Unexpected number of validation errors.");
        }

        [Test]
        public void PeriodShouldBeValidWithPositiveValue()
        {
            var actual = Validator.TryValidateObject(threshold, context, validationResults, true);

            // Assert
            Assert.IsTrue(actual, "Expected validation to pass.");
            Assert.AreEqual(0, validationResults.Count, "Unexpected number of validation errors.");
        }

        [Test]
        public void MaxLoansPerDomainShouldNotBeNegative()
        {
            threshold.MaxLoansPerDomain = -1;
            var actual = Validator.TryValidateObject(threshold, context, validationResults, true);

            // Assert
            Assert.IsFalse(actual, "Expected validation to fail.");
            Assert.AreEqual(1, validationResults.Count, "Unexpected number of validation errors.");
        }

        [Test]
        public void NoOfMonthsShouldNotBeNegative()
        {
            threshold.NoOfMonths = -1;
            var actual = Validator.TryValidateObject(threshold, context, validationResults, true);

            // Assert
            Assert.IsFalse(actual, "Expected validation to fail.");
            Assert.AreEqual(1, validationResults.Count, "Unexpected number of validation errors.");
        }

        [Test]
        public void NoOfMonthsShouldBeValidWithPositiveValue()
        {
            var actual = Validator.TryValidateObject(threshold, context, validationResults, true);

            // Assert
            Assert.IsTrue(actual, "Expected validation to pass.");
            Assert.AreEqual(0, validationResults.Count, "Unexpected number of validation errors.");
        }

        [Test]
        public void LimitLoanExtensionShouldNotBeNegative()
        {
            threshold.LimitLoanExtension = -1;
            var actual = Validator.TryValidateObject(threshold, context, validationResults, true);

            // Assert
            Assert.IsFalse(actual, "Expected validation to fail.");
            Assert.AreEqual(1, validationResults.Count, "Unexpected number of validation errors.");
        }

        [Test]
        public void LimitLoanShouldBeValidWithPositiveValue()
        {
            var actual = Validator.TryValidateObject(threshold, context, validationResults, true);

            // Assert
            Assert.IsTrue(actual, "Expected validation to pass.");
            Assert.AreEqual(0, validationResults.Count, "Unexpected number of validation errors.");
        }

        [Test]
        public void DeltaShouldNotBeNegative()
        {
            threshold.Delta = -1;
            var actual = Validator.TryValidateObject(threshold, context, validationResults, true);

            // Assert
            Assert.IsFalse(actual, "Expected validation to fail.");
            Assert.AreEqual(1, validationResults.Count, "Unexpected number of validation errors.");
        }

        [Test]
        public void DeltaShouldBeValidWithPositiveValue()
        {
            var actual = Validator.TryValidateObject(threshold, context, validationResults, true);

            // Assert
            Assert.IsTrue(actual, "Expected validation to pass.");
            Assert.AreEqual(0, validationResults.Count, "Unexpected number of validation errors.");
        }

        [Test]
        public void MaxLoansPerDayShouldNotBeNegative()
        {
            threshold.MaxLoansPerDay = -1;
            var actual = Validator.TryValidateObject(threshold, context, validationResults, true);

            // Assert
            Assert.IsFalse(actual, "Expected validation to fail.");
            Assert.AreEqual(1, validationResults.Count, "Unexpected number of validation errors.");
        }

        [Test]
        public void MaxLoansPerDayShouldBeValidWithPositiveValue()
        {
            var actual = Validator.TryValidateObject(threshold, context, validationResults, true);

            // Assert
            Assert.IsTrue(actual, "Expected validation to pass.");
            Assert.AreEqual(0, validationResults.Count, "Unexpected number of validation errors.");
        }

        [Test]
        public void ThresholdShouldBeValid()
        {
            Threshold actual = new Threshold(1, 1, 1, 1, 1, 1, 1, 1, 1);
            context = new ValidationContext(actual);
            var isValid = Validator.TryValidateObject(actual, context, validationResults, true);

            // Assert
            Assert.IsTrue(isValid, "Expected validation to pass.");
            Assert.AreEqual(0, validationResults.Count, "Unexpected number of validation errors.");
        }

        [Test]
        public void ThresholdShouldNotBeValid()
        {
            threshold.Delta = -10;
            var actual = Validator.TryValidateObject(threshold, context, validationResults, true);

            // Assert
            Assert.IsFalse(actual, "Expected validation to fail.");
            Assert.AreEqual(1, validationResults.Count, "Unexpected number of validation errors.");
        }
    }
}
