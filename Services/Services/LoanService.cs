// <copyright file="LoanService.cs" company="Transilvania University of Brasov">
// Copyright (c) Alexandra Hermeneanu. All rights reserved.
// </copyright>

namespace Services
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using DataMapper;
    using DomainModel;

    /// <summary>
    /// Loan Servic class.
    /// </summary>
    public class LoanService : Service
    {
        private LoanRepository loanRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="LoanService"/> class.
        /// </summary>
        public LoanService()
        {
            loanRepository = new LoanRepository();
        }

        /// <summary>
        /// Validates the given Loan object.
        /// </summary>
        /// <param name="loan">The loan.</param>
        /// <returns>True or False.</returns>
        public bool IsValidLoan(Loan loan)
        {
            ValidationContext context = new ValidationContext(loan);
            IList<ValidationResult> validationResults = new List<ValidationResult>();

            return Validator.TryValidateObject(loan, context, validationResults, true);
        }

        /// <summary>
        /// Inserts a new Loan object in the database.
        /// </summary>
        /// <param name="loan">The loan.</param>
        /// <returns>True or false.</returns>
        public bool AddNewLoan(Loan loan)
        {
            if (IsValidLoan(loan))
            {
                loanRepository.Insert(loan);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Gets the list of loans.
        /// </summary>
        /// <returns>The list of loans.</returns>
        public IEnumerable<Loan> GetAllLoans()
        {
            return loanRepository.Get(
                orderBy: q => q.OrderBy(c => c.Id),
                includeProperties: "Address");
        }

        /// <summary>
        /// Gets the loan by given ID.
        /// </summary>
        /// <param name="idLoan">The ID of the loan.</param>
        /// <returns>The Book object found.</returns>
        public Loan GetLoanById(int idLoan)
        {
            return loanRepository.GetByID(idLoan);
        }
    }
}
