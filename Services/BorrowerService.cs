﻿using DataMapper;
using DomainModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Services
{
    /// <summary>
    /// Borrower service class.
    /// </summary>
    public class BorrowerService
    {
        /// <summary>
        /// Borrower Repository
        /// </summary>
        private BorrowerRepository borrowerRepository;

        public BorrowerService()
        {
            borrowerRepository = new BorrowerRepository();
        }

        /// <summary>
        /// Validates the given data for a Borrower object.
        /// </summary>
        /// <param name="borrower"></param>
        /// <returns></returns>
        public bool IsValidBorrower(Borrower borrower)
        {
            ValidationContext context = new ValidationContext(borrower);
            IList<ValidationResult> validationResults = new List<ValidationResult>();

            return Validator.TryValidateObject(borrower, context, validationResults, true);
        }

        /// <summary>
        /// Adds new borrower if has valid data.
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="email"></param>
        /// <param name="dob"></param>
        /// <param name="readerFlg"></param>
        /// <param name="librarianFlg"></param>
        /// <returns></returns>
        public bool AddNewBorrower(Borrower newBorrower)
        {
            if (IsValidBorrower(newBorrower))
            {
                borrowerRepository.Insert(newBorrower);
                return true;
            }

            return false;
        }

        public IEnumerable<Borrower> GetAllBorrowers()
        {
            return borrowerRepository.Get(
                orderBy: q => q.OrderBy(c => c.FirstName),
                includeProperties: "Address");
        }

        public Borrower GetBorrower(int id)
        {
            return borrowerRepository.GetByID(id);
        }
    }
}
