using DomainModel;
using NUnit.Framework;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TestDomainModel
{
    [TestFixture]
    public class BorrowerTest
    {
        private Borrower borrower;
        private ValidationContext context;
        private IList<ValidationResult> results;

        [SetUp]
        public void SetUpBorrower()
        {
            borrower = new Borrower()
            {
                Id = 1,
                FirstName = "Alexandra",
                LastName = "Hermeneanu",
                Email = "ale.herm@email.com",
                Gender = EGenderType.EFemale,
                Address = new Address(),
                Loans = new List<Loan> { new Loan() },
                ReaderFlg = 1,
                LibrarianFlg = 0
            };

            context = new ValidationContext(borrower, serviceProvider: null, items: null);
            results = new List<ValidationResult>();
        }

        [Test]
        public void FirstNameShouldNotBeEmpty()
        {
            Assert.IsNotEmpty(borrower.FirstName);
        }

        [Test]
        public void LastNameShouldNotBeEmpty()
        {
            Assert.IsNotEmpty(borrower.LastName);
        }

        [Test]
        public void FirstNameShouldNotBeNull()
        {
            borrower.FirstName = null;

            bool isValid = Validator.TryValidateObject(borrower, context, results);

            Assert.IsFalse(isValid);
        }

        [Test]
        public void LastNameShouldNotBeNull()
        {
            borrower.LastName = null;

            bool isValid = Validator.TryValidateObject(borrower, context, results);

            Assert.IsFalse(isValid);
        }

        //[Test]
        //public void FirstNameShouldHaveLessThan50Characters()
        //{
        //    borrower.FirstName = "Ctdurrsxouepqyxywgbxauksyoyrphtmqclmuekmuhwpkuznqpqaa";
        //    var context = new ValidationContext(borrower, serviceProvider: null, items: null);
        //    var results = new List<ValidationResult>();

        //    bool isValid = Validator.TryValidateObject(borrower, context, results);

        //    Assert.IsFalse(isValid);
        //}
    }
}
