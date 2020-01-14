// <copyright file="IDomainService.cs" company="Transilvania University of Brasov">
// Copyright (c) Alexandra Hermeneanu. All rights reserved.
// </copyright>

namespace Services
{
    using System.Collections.Generic;
    using DomainModel;

    /// <summary>
    /// Interface for the DomainService.
    /// </summary>
    internal interface IDomainService
    {
        /// <summary>
        /// Validates the given Domain object.
        /// </summary>
        /// <param name="domain">The domain.</param>
        /// <returns>True or False.</returns>
        bool IsValidDomain(Domain domain);

        /// <summary>
        /// Inserts a new Domain object in the database.
        /// </summary>
        /// <param name="domain">The domain.</param>
        /// <returns>True or false.</returns>
        bool AddNewDomain(Domain domain);

        /// <summary>
        /// Gets the list of domains.
        /// </summary>
        /// <returns>The list of domains.</returns>
        IEnumerable<Domain> GetAllDomains();

        /// <summary>
        /// Gets the domain by given ID.
        /// </summary>
        /// <param name="idDomain">The ID of the domain.</param>
        /// <returns>The Domain object found.</returns>
        Domain GetDomainById(int idDomain);
    }
}
