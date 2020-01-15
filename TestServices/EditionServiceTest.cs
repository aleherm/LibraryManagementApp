// <copyright file="ServiceTest.cs" company="Transilvania University of Brasov">
// Copyright (c) Alexandra Hermeneanu. All rights reserved.
// </copyright>

namespace TestServices
{
    using DomainModel;
    using NUnit.Framework;
    using Services;

    [TestFixture]
    public class EditionServiceTest : ServiceTest
    {
        /// <summary>
        /// The service instance to be tested.
        /// </summary>
        private EditionService service;

        /// <summary>
        /// The Edition entity based on which the tests will run.
        /// </summary>
        private Edition edition;

        [SetUp]
        public void EditionSetUp()
        {
            service = new EditionService();

            edition = new Edition()
            {
                PageNumber = 100,
                Year = 2019,
                BookType = EBookType.EHardCover,
                Publisher = "Humanitas",
                NoTotal = 10,
                NoForLibrary = 2,
                NoForLoan = 8,
            };
        }

        [Test]
        public override void AddNewInvalidEntityShouldFail()
        {
            edition.Publisher = "Io";
            Assert.IsFalse(service.AddNewEdition(edition), "Expected validation to fail");
        }

        [Test]
        public override void AddNewValidEntityShouldBeSuccessful()
        {
            Assert.IsTrue(service.AddNewEdition(edition), "Expected validation to pass");
        }

        [Test]
        public override void EntityShouldBeValid()
        {
            Assert.AreEqual(true, service.IsValidEdition(edition), "Expected validation to pass");
        }

        [Test]
        public override void EntityShouldNotBeValid()
        {
            edition.Publisher = "N";
            Assert.AreEqual(false, service.IsValidEdition(edition), "Expected validation to fail");
        }
    }
}
