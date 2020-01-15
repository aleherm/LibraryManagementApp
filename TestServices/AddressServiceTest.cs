// <copyright file="AddressTest.cs" company="Transilvania University of Brasov">
// Copyright (c) Alexandra Hermeneanu. All rights reserved.
// </copyright>

namespace TestServices
{
    using DomainModel;
    using NUnit.Framework;
    using Services;

    [TestFixture]
    public class AddressServiceTest : ServiceTest
    {
        /// <summary>
        /// The service instance to be tested.
        /// </summary>
        private AddressService service;

        /// <summary>
        /// The Address entity based on which the tests will run.
        /// </summary>
        private Address address;

        [SetUp]
        public void AddressSetUp()
        {
            service = new AddressService();

            address = new Address()
            {
                City = "Brasov",
                Street = "O. Goga",
                Number = 44,
            };
        }

        [Test]
        public override void AddNewInvalidEntityShouldFail()
        {
            address.City = "Io";
            Assert.IsFalse(service.AddNewAddress(address), "Expected validation to fail");
        }

        [Test]
        public override void AddNewValidEntityShouldBeSuccessful()
        {
            Assert.IsTrue(service.AddNewAddress(address), "Expected validation to pass");
        }

        [Test]
        public override void EntityShouldBeValid()
        {
            Assert.AreEqual(true, service.IsValidAddress(address), "Expected validation to pass");
        }

        [Test]
        public override void EntityShouldNotBeValid()
        {
            address.Street = "N";
            Assert.AreEqual(false, service.IsValidAddress(address), "Expected validation to fail");
        }
    }
}
