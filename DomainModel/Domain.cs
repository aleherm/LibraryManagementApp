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
        [MaxLength(100, ErrorMessage = ErrorMessages.DomainMaxLength)]
        public string DomainName { get; set; }

        public Domain ParentDomain { get; set; }
        
        public IList<Domain> Subdomains { get; set; }

        public Domain()
        {
            Subdomains = new List<Domain>();
        }
    }
}
