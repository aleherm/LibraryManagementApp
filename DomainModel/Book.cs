using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DomainModel
{
    /// <summary>
    /// Book entity class
    /// </summary>
    public class Book
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The name cannot be null.")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "The length must be between 2 and 100.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "The book must have at least one edition.")]
        public IList<Edition> Editions { get; set; }

        [Required(ErrorMessage = "The book must have at least one author.")]
        public IList<Author> Authors { get; set; }

        [Required(ErrorMessage = "The book must cover at least one domain.")]
        public IList<Domain> Domains { get; set; }

        public Book()
        {
            Editions = new List<Edition>();
            Authors = new List<Author>();
            Domains = new List<Domain>();
        }
    }
}
