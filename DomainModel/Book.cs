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

        [Required(ErrorMessage = "The Book Title must be provided.")]
        [MaxLength(100, ErrorMessage = "The Book Title length must have less than 100 characters.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "The book must have at least one Edition.")]
        public IList<Edition> Editions { get; set; }

        [Required(ErrorMessage = "The book must have at least one Author.")]
        public IList<Author> Authors { get; set; }

        [Required(ErrorMessage = "The Book must cover at least one domain / cannot be null.")]
        public IList<Domain> Domains { get; set; }

        public Book()
        {
            Editions = new List<Edition>();
            Authors = new List<Author>();
            Domains = new List<Domain>();
        }
    }
}
