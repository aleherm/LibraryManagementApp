using DomainModel;
using Moq;
using NUnit.Framework;
using Services;
using System;

namespace TestServices
{
    [TestFixture]
    public class BorrowerServiceTest
    {
        /// <summary>
        /// The service instance to be tested.
        /// </summary>
        private BorrowerService service;

        private Borrower newBorrower;

        #region [ Setup ]

        /// <summary>
        /// The setup of the BorrowerService object to be tested.
        /// </summary>
        [SetUp]
        public void BorrowerServiceSetUp()
        {
            service = new BorrowerService();
            Address address = new Address("Brasov", "Octavian", 10);
            newBorrower = new Borrower("Alexandra", "Hermeneanu", "ale@email.com", new DateTime(1999, 10, 10), address, true, false);
        }

        #endregion

        [Test]
        public void BorowerShouldBeValid()
        {
            Assert.AreEqual(service.IsValidBorrower(newBorrower), true);
        }

        [Test]
        public void AddBorowerShouldBeSuccessful()
        {
            Assert.AreEqual(service.AddNewBorrower(newBorrower), true);
        }
    }
}
