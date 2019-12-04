using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DomainModel
{
    /// <summary>
    /// Domain entity class
    /// </summary>
    public class Domain
    {
        public int Id
        {
            get;
            set;
        }

        [Required(ErrorMessage = "The name cannot be null")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "The length must be between 3 and 100")]
        public string DomainName
        {
            get;
            set;
        }

        public Domain ParentDomain { get; set; }

        public IList<Domain> Subdomains { get; set; }

        public Domain()
        {
            Subdomains = new List<Domain>();
            ParentDomain = new Domain();
        }
    }
}
