// <copyright file="BorrowerService.cs" company="Transilvania University of Brasov">
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
    /// Borrower service class.
    /// </summary>
    public class BorrowerService : Service, IBorrowerService
    {
        /// <summary>
        /// Borrower Repository.
        /// </summary>
        private readonly IBorrowerRepository borrowerRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="BorrowerService"/> class.
        /// </summary>
        public BorrowerService()
        {
            borrowerRepository = new BorrowerRepository();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BorrowerService"/> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        public BorrowerService(IBorrowerRepository repository)
        {
            borrowerRepository = repository;
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
