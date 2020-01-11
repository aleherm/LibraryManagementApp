// <copyright file="IEditionService.cs" company="Transilvania University of Brasov">
// Copyright (c) Transilvania University of Brasov. Code by Alexandra Hermeneanu. All rights reserved.
// </copyright>

namespace Services
{
    using System.Collections.Generic;
    using DomainModel;

    /// <summary>
    /// Interface for the BookService.
    /// </summary>
    internal interface IEditionService
    {
        /// <summary>
        /// Validates the given Edition object.
        /// </summary>
        /// <param name="edition">The edition.</param>
        /// <returns>True or False.</returns>
        bool IsValidEdition(Edition edition);

        /// <summary>
        /// Inserts a new Edition object in the database.
        /// </summary>
        /// <param name="edition">The edition.</param>
        /// <returns>True or false.</returns>
        bool AddNewEdition(Edition edition);

        /// <summary>
        /// Gets the list of editions.
        /// </summary>
        /// <returns>The list of editions.</returns>
        IEnumerable<Edition> GetAllEditions();

        /// /// <summary>
        /// Gets the edition by given ID.
        /// </summary>
        /// <param name="idEdition">The ID of the edition.</param>
        /// <returns>The Book object found.</returns>
        Edition GetEditionById(int idEdition);
    }
}
