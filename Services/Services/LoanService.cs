// <copyright file="LoanService.cs" company="Transilvania University of Brasov">
// Copyright (c) Alexandra Hermeneanu. All rights reserved.
// </copyright>

namespace Services
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using DataMapper;
    using DomainModel;

    /// <summary>
    /// Loan Service class.
    /// </summary>
    public class LoanService : Service, ILoanService
    {
        private ILoanRepository loanRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="LoanService"/> class.
        /// </summary>
        public LoanService()
        {
            loanRepository = new LoanRepository();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LoanService"/> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        public LoanService(ILoanRepository repository)
        {
            loanRepository = repository;
        }

        /// <summary>
        /// Validates the given Loan object.
        /// </summary>
        /// <param name="loan">The loan.</param>
        /// <returns>True or False.</returns>
        public bool IsValidLoan(Loan loan)
        {
            bool isValid = true;

            ValidationContext context = new ValidationContext(loan);
            IList<ValidationResult> validationResults = new List<ValidationResult>();

            Validator.TryValidateObject(loan, context, validationResults, true);

            if (validationResults.Count != 0)
            {
                foreach (ValidationResult result in validationResults)
                {
                    ErrorsHandler.Add(result.ErrorMessage);
                }

                isValid = false;
            }
            
            ////if (!isValid)
            ////{
            ////    return false;
            ////}
            
            ////if(loan.BorrowedEditions.Count > Threshold.MaxBooks)
            ////{
            ////    ErrorsHandler.Add(ValidationErrors.TooManyBooks);
            ////    isValid = false;
            ////} else
            ////{
            ////    if(loan.BorrowedEditions.Count >= 3)
            ////    {
            ////        BookService service = new BookService();
            ////        ContainsMoreThatTwoDomains(loan.BorrowedEditions);
            ////    }
            ////}

            foreach (Edition edition in loan.BorrowedEditions)
            {
                if (edition.NoForLoan == 0)
                {
                    ErrorsHandler.Add(ValidationErrors.NoBooksForLoan);
                    isValid = false;
                    break;
                }
                else
                {
                    if (edition.NoForLoan < edition.NoTotal * 0.1)
                    {
                        ErrorsHandler.Add(ValidationErrors.TooFewBooks);
                        isValid = false;
                        break;
                    }
                }
            }

            ////if (!isValid)
            ////{
            ////    return false;
            ////}

            return isValid;
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
