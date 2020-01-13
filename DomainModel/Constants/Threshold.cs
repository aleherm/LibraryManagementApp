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
        /// Gets of sets NoMaxDomains;
        /// </summary>
        public int NoMaxDomains { get; set; }

        /// <summary>
        /// Gets of sets NoMaxLoans.
        /// </summary>
        public int NoMaxLoans { get; set; }

        /// <summary>
        /// Gets of sets Period.
        /// </summary>
        public int Period { get; set; }

        /// <summary>
        /// Gets of sets NoMaxBorrowerPerDomain.
        /// </summary>
        public int NoMaxBorrowerPerDomain { get; set; }

        /// <summary>
        /// Gets of sets NoOfMonths.
        /// </summary>
        public int NoOfMonths { get; set; }

        /// <summary>
        /// Gets of sets LimitLoanExtension.
        /// </summary>
        public int LimitLoanExtension { get; set; }

        /// <summary>
        /// Gets of sets Delta.
        /// </summary>
        public int Delta { get; set; }

        /// <summary>
        /// Gets of sets NoMaxLoansPerDay.
        /// </summary>
        public int NoMaxLoansPerDay { get; set; }

    }
}
