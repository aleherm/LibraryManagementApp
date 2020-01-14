// <copyright file="IRepository.cs" company="Transilvania University of Brasov">
// Copyright (c) Alexandra Hermeneanu. All rights reserved.
// </copyright>

namespace DataMapper
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    /// <summary>
    /// The interface of the base Repository.
    /// </summary>
    /// <typeparam name="T">The type of the entity.</typeparam>
    public interface IRepository<T>
    {
        /// <summary>
        /// Insert new entity.
        /// </summary>
        /// <param name="entity">The entity to be inserted.</param>
        void Insert(T entity);

        /// <summary>
        /// Update the entity.
        /// </summary>
        /// <param name="entity">The entity to be updated.</param>
        void Update(T entity);

        /// <summary>
        /// Delete the entity with given ID.
        /// </summary>
        /// <param name="id">The entity ID to be deleted.</param>
        void Delete(object id);

        /// <summary>
        /// Delete the entity.
        /// </summary>
        /// <param name="entity">The given entity.</param>
        void Delete(T entity);

        /// <summary>
        /// Gets the entity by given ID.
        /// </summary>
        /// <param name="id">The entity ID.</param>
        /// <returns>The found entity.</returns>
        T GetByID(object id);

        /// <summary>
        /// Gets the list of entities.
        /// </summary>
        /// <param name="filter">The filter criteria.</param>
        /// <param name="orderBy">The ordering query.</param>
        /// <param name="includeProperties">The properties to be included.</param>
        /// <returns>The list of entities.</returns>
        IEnumerable<T> Get(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "");
    }
}
