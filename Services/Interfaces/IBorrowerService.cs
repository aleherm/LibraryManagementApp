// <copyright file="IBorrowerService.cs" company="Transilvania University of Brasov">
// Copyright (c) Alexandra Hermeneanu. All rights reserved.
// </copyright>

namespace Services
{
    using System.Collections.Generic;
    using DomainModel;

    /// <summary>
    /// Interface for the BorrowerService.
    /// </summary>
    internal interface IBorrowerService
    {
        /// <summary>
        /// Validates the given Borrower object.
        /// </summary>
        /// <param name="borrower">The borrower.</param>
        /// <returns>True or False.</returns>
        bool IsValidBorrower(Borrower borrower);

        /// <summary>
        /// Inserts a new Borrower object in the database.
        /// </summary>
        /// <param name="borrower">The borrower.</param>
        /// <returns>True or false.</returns>
        bool AddNewBorrower(Borrower borrower);

        /// <summary>
        /// Gets the list of borrowers.
        /// </summary>
        /// <returns>The list of borrowers.</returns>
        IEnumerable<Borrower> GetAllBorrowers();

        /// <summary>
        /// Inserts a new Book object in the database.
        /// </summary>
        /// <param name="idBorrower">The borrower ID.</param>
        /// <returns>True or false.</returns>
        Borrower GetBorrowerById(int idBorrower);
    }
}
