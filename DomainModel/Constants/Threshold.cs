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
        /// 
        /// </summary>
        public int NoMaxDomains { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int NoMaxLoans { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int Period { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int NoMaxBorrowerPerDomain { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int NoOfMonths { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int LimitLoanExtension { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int Delta { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int NoMaxLoansPerDay { get; set; }

    }
}
