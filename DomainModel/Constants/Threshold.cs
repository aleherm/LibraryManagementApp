// <copyright file="Threshold.cs" company="Transilvania University of Brasov">
// Copyright (c) Alexandra Hermeneanu. All rights reserved.
// </copyright>

namespace DomainModel
{
    /// <summary>
    /// Threshold constant data.
    /// </summary>
    public class Threshold
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Threshold"/> class.
        /// </summary>
        public Threshold()
        {
        }

        /// <summary>
        /// Gets of sets the maximum number of domains that a book is allowed to have.
        /// </summary>
        public int NoMaxDomains { get; set; }

        /// <summary>
        /// Gets of sets the maximum number of loans.
        /// </summary>
        public int NoMaxLoans { get; set; }

        /// <summary>
        /// Gets of sets the maximum number of books per period.
        /// </summary>
        public int NoMaxBooks { get; set; }

        /// <summary>
        /// Gets of sets the period between loans.
        /// </summary>
        public int Period { get; set; }

        /// <summary>
        /// Gets of sets the maxim number of loans per domain.
        /// </summary>
        public int NoMaxLoansPerDomain { get; set; }

        /// <summary>
        /// Gets of sets the number of months.
        /// </summary>
        public int NoOfMonths { get; set; }

        /// <summary>
        /// Gets of sets limit for a loan extension for the past 3 months.
        /// </summary>
        public int LimitLoanExtension { get; set; }

        /// <summary>
        /// Gets of sets number of maximum loans for a book.
        /// </summary>
        public int Delta { get; set; }

        /// <summary>
        /// Gets of sets the maximum number of books loaned in a day.
        /// </summary>
        public int NoMaxLoansPerDay { get; set; }
    }
}
