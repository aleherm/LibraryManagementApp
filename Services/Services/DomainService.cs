﻿// <copyright file="DomainService.cs" company="Transilvania University of Brasov">
// Copyright (c) Transilvania University of Brasov. Code by Alexandra Hermeneanu. All rights reserved.
// </copyright>

namespace Services
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using DataMapper;
    using DomainModel;

    /// <summary>
    /// The implementation class of the IDomainService interface.
    /// </summary>
    [SuppressMessage("Microsoft.StyleCop.CSharp.OrderingRules", "SA1101", Justification = "In .NET this is rarely used.")]
    public class DomainService : IDomainService
    {
        private DomainRepository domainRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="DomainService"/> class.
        /// </summary>
        public DomainService()
        {
            domainRepository = new DomainRepository();
        }

        /// <summary>
        /// Validates the given Domain object.
        /// </summary>
        /// <param name="domain">The domain.</param>
        /// <returns>True or False.</returns>
        public bool IsValidDomain(Domain domain)
        {
            ValidationContext context = new ValidationContext(domain);
            IList<ValidationResult> validationResults = new List<ValidationResult>();

            return Validator.TryValidateObject(domain, context, validationResults, true);
        }

        /// <summary>
        /// Inserts a new Domain object in the database.
        /// </summary>
        /// <param name="domain">The domain.</param>
        /// <returns>True or false.</returns>
        public bool AddNewDomain(Domain domain)
        {
            if (IsValidDomain(domain))
            {
                domainRepository.Insert(domain);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Gets the list of domains.
        /// </summary>
        /// <returns>The list of domains.</returns>
        public IEnumerable<Domain> GetAllDomains()
        {
            return domainRepository.Get(
                orderBy: q => q.OrderBy(c => c.Id));
        }

        /// <summary>
        /// Gets the domain by given ID.
        /// </summary>
        /// <param name="idDomain">The ID of the domain.</param>
        /// <returns>The Domain object found.</returns>
        public Domain GetDomainById(int idDomain)
        {
            return domainRepository.GetByID(idDomain);
        }
    }
}