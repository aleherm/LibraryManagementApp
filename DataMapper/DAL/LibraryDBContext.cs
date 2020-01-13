// <copyright file="LibraryDBContext.cs" company="Transilvania University of Brasov">
// Copyright (c) Transilvania University of Brasov. Code by Alexandra Hermeneanu. All rights reserved.
// </copyright>

namespace DataMapper
{
    using System.Data.Entity;
    using DomainModel;

    /// <summary>
    /// The database context.
    /// </summary>
    public class LibraryDBContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LibraryDBContext"/> class.
        /// </summary>
        public LibraryDBContext()
            : base("strLibraryConnection")
        {
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<LibraryDBContext, Migrations.Configuration>());
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
