using DomainModel;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDomainModel
{
    [TestFixture]
    public class LoanTest
    {
        private Loan loan;

        private ValidationContext context;
        private IList<ValidationResult> results;

        [SetUp]
        public void LoanSetup()
        {
            loan = new Loan()
            {
                Id = 1,
                DueDate = new DateTime(2019, 2, 1),
                ReturnDate = new DateTime(),
                //Borrower = new Borrower()
                //{
                //    FirstName = "Ioan",
                //    LastName = "Marian",
                //    Email = "ioan@marian.com",
                //    Gender = EGenderType.EMale,
                //    Loans = new List<Loan>()
                //}
            };

            context = new ValidationContext(loan, serviceProvider: null, items: null);
            results = new List<ValidationResult>();
        }

        //[Test]
        //public void BorrowerShouldNotBeNull()
        //{
        //    loan.Borrower = null;

        //    bool isValid = Validator.TryValidateObject(loan, context, results);

        //    Assert.IsFalse(isValid);
        //}
    }
}
