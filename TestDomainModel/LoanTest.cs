namespace TestDomainModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Diagnostics.CodeAnalysis;
    using DomainModel;
    using NUnit.Framework;

    /// <summary>
    /// Tests the Loan entity.
    /// </summary>
    [SuppressMessage("Microsoft.StyleCop.CSharp.OrderingRules", "SA1101", Justification = "In .NET this is rarely used.")]
    [TestFixture]
    public class LoanTest
    {
        private Loan loan;

        private ValidationContext context;
        private IList<ValidationResult> results;

        /// <summary>
        /// Sets up valid properties for the object to be tested.
        /// </summary>
        [SetUp]
        public void LoanSetup()
        {
            loan = new Loan()
            {
                Id = 1,
                DueDate = new DateTime(2019, 2, 1),
                ReturnDate = new DateTime(2019, 10, 10),
            };

            context = new ValidationContext(loan, serviceProvider: null, items: null);
            results = new List<ValidationResult>();
        }
    }
}
