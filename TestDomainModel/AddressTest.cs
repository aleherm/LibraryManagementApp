﻿using DomainModel;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TestDomainModel
{
    [TestFixture]
    public class AddressTest
    {
        #region [ Declarations ]

        /// <summary>
        /// Address object to test.
        /// </summary>
        private Address address;

        /// <summary>
        /// The Address validation context.
        /// </summary>
        private ValidationContext context;

        /// <summary>
        /// Validation errors returned.
        /// </summary>
        private IList<ValidationResult> validationResults;

        #endregion

        #region [ Setup ]

        /// <summary>
        /// The setup of the Address object to be tested.
        /// </summary>
        [SetUp]
        public void AddressSetUp()
        {
            address = new Address()
            {
                City = "Brasov",
                Street = "O. Goga",
                Number = 44
            };

            context = new ValidationContext(address);
            validationResults = new List<ValidationResult>();
        }

        #endregion

        #region [ Required Tests ]

        [Test]
        public void CityShouldNotBeNull()
        {
            address.City = null;

            var actual = Validator.TryValidateObject(address, context, validationResults, true);

            // Assert
            Assert.IsFalse(actual, "Expected validation to fail.");
            Assert.AreEqual(1, validationResults.Count, "Unexpected number of validation errors.");
            var msg = validationResults[0];
            Assert.AreEqual(ErrorMessages.CityNameRequired, msg.ErrorMessage);
        }

        [Test]
        public void StreetShouldNotBeNull()
        {
            address.Street = null;

            var actual = Validator.TryValidateObject(address, context, validationResults, true);

            // Assert
            Assert.IsFalse(actual, "Expected validation to fail.");
            Assert.AreEqual(1, validationResults.Count, "Unexpected number of validation errors.");
            var msg = validationResults[0];
            Assert.AreEqual(ErrorMessages.StreetNameRequired, msg.ErrorMessage);
        }

        [Test]
        public void NumberShouldNotBeNull()
        {
            address.Number = null;

            var actual = Validator.TryValidateObject(address, context, validationResults, true);

            // Assert
            Assert.IsFalse(actual, "Expected validation to fail.");
            Assert.AreEqual(1, validationResults.Count, "Unexpected number of validation errors.");
            var msg = validationResults[0];
            Assert.AreEqual(ErrorMessages.HouseNumberRequired, msg.ErrorMessage);
        }

        #endregion

        #region [ City Tests ]

        [Test]
        public void CityNameShouldNotHaveLessThan5Characters()
        {
            address.City = "Xo";
            
            bool actual = Validator.TryValidateObject(address, context, validationResults, true);

            // Assert
            Assert.IsFalse(actual, "Expected validation to fail.");
            Assert.AreEqual(1, validationResults.Count, "Unexpected number of validation errors.");
        }

        [Test]
        public void CityNameBetween5And50CharactersShouldBeValid()
        {
            bool actual = Validator.TryValidateObject(address, context, validationResults, true);

            // Assert
            Assert.IsTrue(actual, "Expected validation to fail.");
            Assert.AreEqual(0, validationResults.Count, "Unexpected number of validation errors.");
        }

        [Test]
        public void CityNameShouldNotHaveMoreThan50Characters()
        {
            address.City = new string('x', 51);
            
            bool actual = Validator.TryValidateObject(address, context, validationResults, true);

            // Assert
            Assert.IsFalse(actual, "Expected validation to fail.");
            Assert.AreEqual(1, validationResults.Count, "Unexpected number of validation errors.");
        }

        #endregion

        #region [ Street ]

        [Test, Sequential]
        public void StreetShouldNotHaveNoOfCharsOutsideRange([Values("A", "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "")] string streetName)
        {
            address.Street = streetName;

            bool actual = Validator.TryValidateObject(address, context, validationResults, true);

            // Assert
            Assert.IsFalse(actual, "Expected validation to fail.");
            Assert.AreEqual(1, validationResults.Count, "Unexpected number of validation errors.");
        }

        #endregion

        #region [ Number Tests ]
        
        [Test]
        public void PositiveHouseNumberShouldBeValid()
        {
            // Act
            var validationResults = new List<ValidationResult>();
            var actual = Validator.TryValidateObject(address, new ValidationContext(address), validationResults, true);

            // Assert
            Assert.IsTrue(actual, "Expected validation to succeed.");
            Assert.AreEqual(0, validationResults.Count, "Unexpected number of validation errors.");
        }

        [Test]
        public void NumberShouldNotBeZero()
        {
            address.Number = 0;

            bool isValid = Validator.TryValidateObject(address, context, validationResults);

            Assert.IsFalse(isValid);
        }

        [Test]
        public void NegativeHouseNumberShouldNotBeValid()
        {
            address.Number = -1;

            // Act
            var validationResults = new List<ValidationResult>();
            var actual = Validator.TryValidateObject(address, new ValidationContext(address), validationResults, true);

            // Assert
            Assert.IsFalse(actual, "Expected validation to fail.");
            Assert.AreEqual(1, validationResults.Count, "Unexpected number of validation errors.");
        }

        #endregion
    }
}