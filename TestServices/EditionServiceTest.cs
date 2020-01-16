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

        [Test]
        public void GetAllEditionsValidCall()
        {
            var mockedEditionService = new Mock<IEditionService>();
            mockedEditionService.Setup(x => x.GetAllEditions()).Returns(GetAllSampleEditions());

            IEditionService mockService = mockedEditionService.Object;

            IEnumerable<Edition> expected = mockService.GetAllEditions();
            IEnumerable<Edition> actual = GetAllSampleEditions();

            Assert.True(EnumerableExtensions.HasSameElementsAs<Edition>(expected, actual));
        }

        [Test]
        public void GetEditionByIdValidCall()
        {
            var mockedEditionService = new Mock<IEditionService>();
            mockedEditionService.Setup(x => x.GetEditionById(It.IsAny<int>())).Returns(edition);

            IEditionService mockService = mockedEditionService.Object;
            Edition expected = edition;
            Edition actual = mockService.GetEditionById(1);

            Assert.AreEqual(expected, actual, "Expected to have the same values");
        }

        /// <summary>
        /// Gets all sample editiones.
        /// </summary>
        /// <returns></returns>
        private IEnumerable<Edition> GetAllSampleEditions()
        {
            List<Edition> output = new List<Edition>()
            {
                new Edition()
                {
                    PageNumber = 100,
                    Year = 2019,
                    BookType = EBookType.EHardCover,
                    Publisher = "Humanitas",
                    NoTotal = 10,
                    NoForLibrary = 2,
                    NoForLoan = 8,
                },
            };

            return output;
        }
    }
}
