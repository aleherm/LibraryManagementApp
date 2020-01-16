// <copyright file="AddressTest.cs" company="Transilvania University of Brasov">
// Copyright (c) Alexandra Hermeneanu. All rights reserved.
// </copyright>

namespace TestServices
{
    using System.Collections.Generic;
    using DomainModel;
    using Moq;
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

        [Test]
        public void GetAllAddressesValidCall()
        {
            var mockedAddressService = new Mock<IAddressService>();
            mockedAddressService.Setup(x => x.GetAllAddresses()).Returns(GetAllSampleAddresses());

            IAddressService mockService = mockedAddressService.Object;

            IEnumerable<Address> expected = mockService.GetAllAddresses();
            IEnumerable<Address> actual = GetAllSampleAddresses();

            Assert.True(EnumerableExtensions.HasSameElementsAs<Address>(expected, actual));
        }

        [Test]
        public void GetAddressByIdValidCall()
        {
            var mockedAddressService = new Mock<IAddressService>();
            mockedAddressService.Setup(x => x.GetAddressById(It.IsAny<int>())).Returns(address);

            IAddressService mockService = mockedAddressService.Object;
            Address expected = address;
            Address actual = mockService.GetAddressById(1);

            Assert.AreEqual(expected, actual, "Expected to have the same values");
        }

        /// <summary>
        /// Gets all sample addresses.
        /// </summary>
        /// <returns></returns>
        private IEnumerable<Address> GetAllSampleAddresses()
        {
            List<Address> output = new List<Address>()
            {
                new Address
                {
                    Id = 1,
                    City = "City1",
                    Street = "Street1",
                    Number = 1,
                },
                new Address
                {
                    Id = 1,
                    City = "City2",
                    Street = "Street2",
                    Number = 2,
                }
            };

            return output;
        }
    }
}
