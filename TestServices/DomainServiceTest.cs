// <copyright file="ServiceTest.cs" company="Transilvania University of Brasov">
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
    public class DomainServiceTest : ServiceTest
    {
        /// <summary>
        /// The service instance to be tested.
        /// </summary>
        private DomainService service;

        /// <summary>
        /// The Domain entity based on which the tests will run.
        /// </summary>
        private Domain domain;

        [SetUp]
        public void DomainSetUp()
        {
            service = new DomainService();

            domain = new Domain()
            {
                Id = 2,
                DomainName = "Mathematics",
                ParentDomain = new Domain()
                {
                    Id = 1,
                    DomainName = "Science",
                    ParentDomain = null,
                    Books = new List<Book>(),
                },
                Subdomains = new List<Domain>(),
                Books = new List<Book>(),
            };
        }

        [Test]
        public override void AddNewInvalidEntityShouldFail()
        {
            domain.DomainName = "Io";
            Assert.IsFalse(service.AddNewDomain(domain), "Expected validation to fail");
        }

        [Test]
        public override void AddNewValidEntityShouldBeSuccessful()
        {
            Assert.IsTrue(service.AddNewDomain(domain), "Expected validation to pass");
        }

        [Test]
        public override void EntityShouldBeValid()
        {
            Assert.AreEqual(true, service.IsValidDomain(domain), "Expected validation to pass");
        }

        [Test]
        public override void EntityShouldNotBeValid()
        {
            domain.DomainName = "N";
            Assert.AreEqual(false, service.IsValidDomain(domain), "Expected validation to fail");
        }

        [Test]
        public void GetAllDomainValidCall()
        {
            var mockedDomainService = new Mock<IDomainService>();
            mockedDomainService.Setup(x => x.GetAllDomains()).Returns(GetAllSampleDomain());

            IDomainService mockService = mockedDomainService.Object;

            IEnumerable<Domain> expected = mockService.GetAllDomains();
            IEnumerable<Domain> actual = GetAllSampleDomain();

            Assert.True(EnumerableExtensions.HasSameElementsAs<Domain>(expected, actual));
        }

        [Test]
        public void GetDomainByIdValidCall()
        {
            var mockedDomainService = new Mock<IDomainService>();
            mockedDomainService.Setup(x => x.GetDomainById(It.IsAny<int>())).Returns(domain);

            IDomainService mockService = mockedDomainService.Object;
            Domain expected = domain;
            Domain actual = mockService.GetDomainById(1);

            Assert.AreEqual(expected, actual, "Expected to have the same values");
        }

        /// <summary>
        /// Gets all sample domain.
        /// </summary>
        /// <returns></returns>
        private IEnumerable<Domain> GetAllSampleDomain()
        {
            List<Domain> output = new List<Domain>()
            {
                new Domain()
                {
                    Id = 2,
                    DomainName = "Mathematics",
                    ParentDomain = new Domain()
                    {
                        Id = 1,
                        DomainName = "Science",
                        ParentDomain = null
                    },
                },
                new Domain()
                {
                    Id = 3,
                    DomainName = "Informatics",
                    ParentDomain = null,
                },
            };

            return output;
        }
    }
}
