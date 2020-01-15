// <copyright file="Threshold.cs" company="Transilvania University of Brasov">
// Copyright (c) Alexandra Hermeneanu. All rights reserved.
// </copyright>

namespace DomainModel
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Threshold constant data.
    /// </summary>
    public class Threshold : IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Threshold"/> class.
        /// </summary>
        public Threshold()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Threshold" /> class.
        /// </summary>
        /// <param name="maxDomains">The maximum domains.</param>
        /// <param name="maxLoans">The maximum loans.</param>
        /// <param name="period">The period.</param>
        /// <param name="maxBooks">The maximum books loan.</param>
        /// <param name="maxLoansPerDomain">The maximum loans per domain.</param>
        /// <param name="noOfMonths">The no of months.</param>
        /// <param name="limitLoanExtension">The limit loan extension.</param>
        /// <param name="delta">The delta.</param>
        /// <param name="maxLoansPerDay">The maximum loans per day.</param>
        public Threshold(int maxDomains, int maxLoans, int period, int maxBooks, int maxLoansPerDomain, int noOfMonths, int limitLoanExtension, int delta, int maxLoansPerDay)
        {
            MaxDomains = maxDomains;
            MaxLoans = maxLoans;
            Period = period;
            MaxBooks = maxBooks;
            MaxLoansPerDomain = maxLoansPerDomain;
            NoOfMonths = noOfMonths;
            LimitLoanExtension = limitLoanExtension;
            Delta = delta;
            MaxLoansPerDay = maxLoansPerDay;
        }

        /// <summary>
        /// Gets of sets the [maximum number of domains per book] - DOM.
        /// </summary>
        /// <value>
        /// The maximum domains.
        /// </value>
        public int MaxDomains { get; set; }

        /// <summary>
        /// Gets of sets the [maximum number of loans in the specified period underneath] - NMC.
        /// </summary>
        /// <value>
        /// The maximum loans.
        /// </value>
        public int MaxLoans { get; set; }

        /// <summary>
        /// Gets of sets the [period for the maximum loan number] from top - PER.
        /// </summary>
        /// <value>
        /// The period.
        /// </value>
        public int Period { get; set; }

        /// <summary>
        /// Gets of sets the [maximum number of books that can be taken per loan].
        /// </summary>
        /// <value>
        /// The maximum editions.
        /// </value>
        public int MaxBooks { get; set; }

        /// <summary>
        /// Gets of sets the [maximum number of books that can be loaned per domain].
        /// </summary>
        /// <value>
        /// The maximum loans per domain.
        /// </value>
        public int MaxLoansPerDomain { get; set; }

        /// <summary>
        /// Gets of sets the [number of months in which no more than D books can be loaned] - L.
        /// </summary>
        /// <value>
        /// The no of months.
        /// </value>
        public int NoOfMonths { get; set; }

        /// <summary>
        /// Gets of sets limit for a loan extension for the past 3 months.
        /// </summary>
        /// <value>
        /// The limit loan extension.
        /// </value>
        public int LimitLoanExtension { get; set; }

        /// <summary>
        /// Gets of sets the period between loans of the same book.
        /// </summary>
        /// <value>
        /// The delta.
        /// </value>
        public int Delta { get; set; }

        /// <summary>
        /// Gets of sets the maximum number of books loaned in a day.
        /// </summary>
        /// <value>
        /// The maximum loans per day.
        /// </value>
        public int MaxLoansPerDay { get; set; }
        
        /// <summary>
        /// Determines whether the specified object is valid.
        /// </summary>
        /// <param name="validationContext">The validation context.</param>
        /// <returns>
        /// A collection that holds failed-validation information.
        /// </returns>
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<string> memberNames = new List<string>();
            if (MaxDomains < 0)
            {
                memberNames.Add("MaxDomains");
            }

            if (MaxLoans < 0)
            {
                memberNames.Add("MaxLoans");
            }

            if (Period < 0)
            {
                memberNames.Add("Period");
            }

            if (MaxBooks < 0)
            {
                memberNames.Add("MaxBooks");
            }

            if (MaxLoansPerDomain < 0)
            {
                memberNames.Add("MaxLoansPerDomain");
            }

            if (NoOfMonths < 0)
            {
                memberNames.Add("NoOfMonths");
            }

            if (Delta < 0)
            {
                memberNames.Add("Delta");
            }

            if (MaxLoansPerDay < 0)
            {
                memberNames.Add("Delta");
            }
            
            yield return new ValidationResult(ErrorMessages.NegativeThreshold, memberNames);
        }
    }
}
