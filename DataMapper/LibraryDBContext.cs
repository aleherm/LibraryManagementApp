using DomainModel;
using System.Data.Entity;

namespace DataMapper
{
    public class LibraryDBContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LibraryDBContext"/> class.
        /// </summary>
        public LibraryDBContext() : base("DatabaseConnectionString")
        {

        }

        /// <summary>
        /// Gets or sets the books.
        /// </summary>
        /// <value>
        /// The customers.
        /// </value>
        public virtual DbSet<Book> Books { get; set; }
    }
}
