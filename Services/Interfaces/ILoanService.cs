// <copyright file="ILoanService.cs" company="Transilvania University of Brasov">
// Copyright (c) Alexandra Hermeneanu. All rights reserved.
// </copyright>

namespace Services
{
    using System.Collections.Generic;
    using DomainModel;

    /// <summary>
    /// Interface for the BookService.
    /// </summary>
    public interface ILoanService 
    {
        /// <summary>
        /// Validates the given Loan object.
        /// </summary>
        /// <param name="loan">The loan.</param>
        /// <returns>True or False.</returns>
        bool IsValidLoan(Loan loan);

        /// <summary>
        /// Inserts a new Loan object in the database.
        /// </summary>
        /// <param name="loan">The loan.</param>
        /// <returns>True or false.</returns>
        bool AddNewLoan(Loan loan);

        /// <summary>
        /// Gets the list of loans.
        /// </summary>
        /// <returns>The list of loans.</returns>
        IEnumerable<Loan> GetAllLoans();

        /// <summary>
        /// Gets the loan by given ID.
        /// </summary>
        /// <param name="idLoan">The ID of the loan.</param>
        /// <returns>The Book object found.</returns>
        Loan GetLoanById(int idLoan);
    }
}