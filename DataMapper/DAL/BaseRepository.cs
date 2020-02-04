// <copyright file="BaseRepository.cs" company="Transilvania University of Brasov">
// Copyright (c) Alexandra Hermeneanu. All rights reserved.
// </copyright>

namespace DataMapper
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;
    using log4net;

    /// <summary>
    /// Basic data access methods class.
    /// </summary>
    /// <typeparam name="T">The type of the entity.</typeparam>
    [System.Diagnostics.CodeAnalysis.SuppressMessage(
    "Microsoft.StyleCop.CSharp.NamingRules",
    "SA1305:FieldNamesMustNotUseHungarianNotation",
    Justification = "Using Win32 naming for consistency.")]
    public abstract class BaseRepository<T> : IRepository<T>
        where T : class
    {
        /// <summary>
        /// The log.
        /// </summary>
        protected static readonly ILog Log = LogManager.GetLogger(typeof(BaseRepository<T>));

        /// <summary>
        /// Gets the list of entities based on given type.
        /// </summary>
        /// <param name="filter">The filter criteria.</param>
        /// <param name="orderBy">The ordering query.</param>
        /// <param name="includeProperties">Properties to be included.</param>
        /// <returns>The list of asked entities.</returns>
        public virtual IEnumerable<T> Get(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "")
        {
            using (var ctx = new LibraryDBContext())
            {
                var dbSet = ctx.Set<T>();

                IQueryable<T> query = dbSet;

                if (filter != null)
                {
                    query = query.Where(filter);
                }

                foreach (var includeProperty in includeProperties.Split(
                    new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }

                if (orderBy != null)
                {
                    return orderBy(query).ToList();
                }
                else
                {
                    return query.ToList();
                }
            }
        }

        /// <summary>
        /// Inserts a given entity in the database.
        /// </summary>
        /// <param name="entity">The entity to be inserted.</param>
        public virtual void Insert(T entity)
        {
            using (var ctx = new LibraryDBContext())
            {
                var dbSet = ctx.Set<T>();
                dbSet.Add(entity);

                ctx.SaveChanges();

                Log.Info("Entity of type " + entity.GetType().ToString() + " have been successfully inserted!");
            }
        }

        /// <summary>
        /// Updates a given entity in the database.
        /// </summary>
        /// <param name="item">The modified entity.</param>
        public virtual void Update(T item)
        {
            using (var ctx = new LibraryDBContext())
            {
                var dbSet = ctx.Set<T>();
                dbSet.Attach(item);
                ctx.Entry(item).State = EntityState.Modified;

                ctx.SaveChanges();

                Log.Info("Entity of type " + item.GetType().ToString() + " have been successfully updated!");
            }
        }

        /// <summary>
        /// Deletes a given entity based on ID from the database.
        /// </summary>
        /// <param name="id">The ID of the entity.</param>
        public virtual void Delete(object id)
        {
            T entity = GetByID(id);
            this.Delete(entity);

            Log.Info("Entity of type " + entity.GetType().ToString() + " have been successfully deleted!");
        }

        /// <summary>
        /// Deletes a given entity from the database.
        /// </summary>
        /// <param name="entityToDelete">The entity to delete.</param>
        public virtual void Delete(T entityToDelete)
        {
            using (var ctx = new LibraryDBContext())
            {
                var dbSet = ctx.Set<T>();

                if (ctx.Entry(entityToDelete).State == EntityState.Detached)
                {
                    dbSet.Attach(entityToDelete);
                }

                dbSet.Remove(entityToDelete);

                ctx.SaveChanges();

                Log.Info("Entity of type " + entityToDelete.GetType().ToString() + " have been successfully deleted!");
            }
        }

        /// <summary>
        /// Gets the entity based on given ID.
        /// </summary>
        /// <param name="id">The ID of the entity.</param>
        /// <returns>The entity.</returns>
        public virtual T GetByID(object id)
        {
            using (var ctx = new LibraryDBContext())
            {
                Log.Info("Entity with ID " + id.ToString() + " have been successfully deleted!");

                return ctx.Set<T>().Find(id);
            }
        }
    }
}
