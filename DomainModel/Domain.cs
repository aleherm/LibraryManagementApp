using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DomainModel
{
    /// <summary>
    /// Domain entity class
    /// </summary>
    public class Domain
    {
        public int Id { get; set; }

        [Required(ErrorMessage = ErrorMessages.DomainNameRequired)]
        [StringLength(100, ErrorMessage = ErrorMessages.DomainNameRangeLength, MinimumLength = 5)]
        public string DomainName { get; set; }

        public Domain ParentDomain { get; set; }

        [Required(ErrorMessage = ErrorMessages.SubdomainRequired)]
        public IList<Domain> Subdomains { get; set; }

        public List<Book> Books { get; set; }

        public Domain()
        {
            Subdomains = new List<Domain>();
            Books = new List<Book>();
        }

        public Domain(string domainName, Domain parent, List<Domain> subdomains)
        {
            DomainName = domainName;
            ParentDomain = parent;
            Subdomains = subdomains;
            Books = new List<Book>();
        }

        public override string ToString()
        {
            return $"{DomainName} | {ParentDomain}";
        }
    }
}
