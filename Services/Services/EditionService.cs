// <copyright file="EditionService.cs" company="Transilvania University of Brasov">
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
    /// Edition Service class.
    /// </summary>
    public class EditionService : Service, IEditionService
    {
        private IEditionRepository editionRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="EditionService"/> class.
        /// </summary>
        public EditionService()
        {
            editionRepository = new EditionRepository();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EditionService"/> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        public EditionService(IEditionRepository repository)
        {
            editionRepository = repository;
        }

        /// <summary>
        /// Validates the given Edition object.
        /// </summary>
        /// <param name="edition">The edition.</param>
        /// <returns>True or False.</returns>
        public bool IsValidEdition(Edition edition)
        {
            ValidationContext context = new ValidationContext(edition);
            IList<ValidationResult> validationResults = new List<ValidationResult>();

            return Validator.TryValidateObject(edition, context, validationResults, true);
        }

        /// <summary>
        /// Inserts a new Edition object in the database.
        /// </summary>
        /// <param name="edition">The edition.</param>
        /// <returns>True or false.</returns>
        public bool AddNewEdition(Edition edition)
        {
            if (IsValidEdition(edition))
            {
                editionRepository.Insert(edition);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Gets the list of editions.
        /// </summary>
        /// <returns>The list of editions.</returns>
        public IEnumerable<Edition> GetAllEditions()
        {
            return editionRepository.Get(
                orderBy: q => q.OrderBy(c => c.Publisher),
                includeProperties: "Address");
        }

        /// <summary>
        /// Gets the edition by given ID.
        /// </summary>
        /// <param name="idEdition">The ID of the edition.</param>
        /// <returns>The Book object found.</returns>
        public Edition GetEditionById(int idEdition)
        {
            return editionRepository.GetByID(idEdition);
        }
    }
}
