using DomainModel;
using System.Data.Entity;

namespace DataMapper
{
    public class LibraryDBContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LibraryDBContext"/> class.
        /// </summary>
        public LibraryDBContext() : base("strLibraryConnection")
        {

        }

        /// <summary>
        /// Gets or sets the Addresses.
        /// </summary>
        /// <value>
        /// The addresses.
        /// </value>
        public virtual DbSet<Address> Addresses { get; set; }

        /// <summary>
        /// Gets or sets the authors.
        /// </summary>
        /// <value>
        /// The authors.
        /// </value>
        public virtual DbSet<Author> Authors { get; set; }

        /// <summary>
        /// Gets or sets the books.
        /// </summary>
        /// <value>
        /// The books.
        /// </value>
        public virtual DbSet<Book> Books { get; set; }


        /// <summary>
        /// Gets or sets the Borrowers.
        /// </summary>
        /// <value>
        /// The borrowers.
        /// </value>
        public virtual DbSet<Borrower> Borrowers { get; set; }

        /// <summary>
        /// Gets or sets the Domains.
        /// </summary>
        /// <value>
        /// The domains.
        /// </value>
        public virtual DbSet<Domain> Domains { get; set; }

        /// <summary>
        /// Gets or sets the Editions.
        /// </summary>
        /// <value>
        /// The editions.
        /// </value>
        public virtual DbSet<Edition> Editions { get; set; }

        /// <summary>
        /// Gets or sets the Loans.
        /// </summary>
        /// <value>
        /// The loans.
        /// </value>
        public virtual DbSet<Loan> Loans { get; set; }

    }
}
