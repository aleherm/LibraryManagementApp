// <copyright file="AddressTest.cs" company="Transilvania University of Brasov">
// Copyright (c) Alexandra Hermeneanu. All rights reserved.
// </copyright>

namespace TestServices
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using DataMapper;
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
        private IAddressService service;

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
            var mockedAddressRepository = new Mock<IAddressRepository>();
            mockedAddressRepository.Setup(x => x.Get(
                It.IsAny<Expression<Func<Address, bool>>>(),
                It.IsAny<Func<IQueryable<Address>, IOrderedQueryable<Address>>>(),
                It.IsAny<string>())).Returns(GetAllSampleAddresses());

            IAddressService mockService = new AddressService(mockedAddressRepository.Object);

            IEnumerable<Address> expected = mockService.GetAllAddresses();
            IEnumerable<Address> actual = GetAllSampleAddresses();

            Assert.True(EnumerableExtensions.HasSameElementsAs<Address>(expected, actual));
        }

        [Test]
        public void GetAddressByIdValidCall()
        {
            var mockedAddressRepository = new Mock<IAddressRepository>();
            mockedAddressRepository.Setup(x => x.GetByID(It.IsAny<int>())).Returns(address);

            IAddressService mockService = new AddressService(mockedAddressRepository.Object);
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
