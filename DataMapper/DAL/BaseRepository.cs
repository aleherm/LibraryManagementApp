namespace DataMapper
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;

    /// <summary>
    /// Basic data access methods.
    /// </summary>
    public abstract class BaseRepository<T> : IRepository<T> 
        where T : class
    {
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

                foreach (var includeProperty in includeProperties.Split
                    (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
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
            }
        }

        /// <summary>
        /// Deletes a given entity based on ID from the database.
        /// </summary>
        /// <param name="id">The ID of the entity.</param>
        public virtual void Delete(object id)
        {
            this.Delete(this.GetByID(id));
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
                return ctx.Set<T>().Find(id);
            }
        }
    }
}
