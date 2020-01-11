// <copyright file="BorrowerService.cs" company="Transilvania University of Brasov">
// Copyright (c) Transilvania University of Brasov. Code by Alexandra Hermeneanu. All rights reserved.
// </copyright>

namespace Services
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using DataMapper;
    using DomainModel;

    /// <summary>
    /// Borrower service class.
    /// </summary>
    [SuppressMessage("Microsoft.StyleCop.CSharp.OrderingRules", "SA1101", Justification = "In .NET this is rarely used.")]
    public class BorrowerService
    {
        /// <summary>
        /// Borrower Repository.
        /// </summary>
        private readonly BorrowerRepository borrowerRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="BorrowerService"/> class.
        /// </summary>
        public BorrowerService()
        {
            borrowerRepository = new BorrowerRepository();
        }

        /// <summary>
        /// Validates the given data for a Borrower object.
        /// </summary>
        /// <param name="borrower">The borrower.</param>
        /// <returns>True of False.</returns>
        public bool IsValidBorrower(Borrower borrower)
        {
            ValidationContext context = new ValidationContext(borrower);
            IList<ValidationResult> validationResults = new List<ValidationResult>();

            return Validator.TryValidateObject(borrower, context, validationResults, true);
        }

        /// <summary>
        /// Inserts a new Borrower object in the database.
        /// </summary>
        /// <param name="borrower">The borrower.</param>
        /// <returns>True or false.</returns>
        public bool AddNewBorrower(Borrower borrower)
        {
            if (IsValidBorrower(borrower))
            {
                borrowerRepository.Insert(borrower);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Gets the list of borrowers.
        /// </summary>
        /// <returns>The list of borrowers.</returns>
        public IEnumerable<Borrower> GetAllBorrowers()
        {
            return borrowerRepository.Get(
                orderBy: q => q.OrderBy(c => c.FirstName),
                includeProperties: "Address");
        }

        /// <summary>
        /// Gets the borrower by given ID.
        /// </summary>
        /// <param name="idBorrower">The ID of the borrower.</param>
        /// <returns>The Borrower object found.</returns>
        public Borrower GetBorrowerById(int idBorrower)
        {
            return borrowerRepository.GetByID(idBorrower);
        }
    }
}
