using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DomainModel
{
    /// <summary>
    /// Book entity class
    /// </summary>
    public class Book : IValidatableObject
    {
        public int Id { get; set; }

        [Required(ErrorMessage = ErrorMessages.BookTitleRequired)]
        [StringLength(100, MinimumLength = 2, ErrorMessage = ErrorMessages.BookTitleRangeLength)]
        public string Title { get; set; }

        [Required(ErrorMessage = ErrorMessages.AuthorRequired)]
        public IList<Author> Authors { get; set; }

        [Required(ErrorMessage = ErrorMessages.DomainRequired)]
        public IList<Domain> Domains { get; set; }

        [Required(ErrorMessage = ErrorMessages.EditionRequired)]
        public IList<Edition> Editions { get; set; }
        
        public Book()
        {
            Authors = new List<Author>();
            Domains = new List<Domain>();
            Editions = new List<Edition>();
        }

        public Book(string title, List<Author> authors, List<Domain> domains, List<Edition> editions)
        {
            Title = title;
            Authors = authors;
            Domains = domains;
            Editions = editions;
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<string> memberNames = new List<string>();

            if (Authors != null && Authors.Count == 0)
            {
                memberNames.Add("Authors");
            }

            if (Domains != null && Domains.Count == 0)
            {
                memberNames.Add("Domains");
            }

            if (Editions != null && Editions.Count == 0)
            {
                memberNames.Add("Editions");
            }

            if (memberNames.Count != 0)
            {
                yield return new ValidationResult(ErrorMessages.ListRequireAtLeastOneObject, memberNames);
            }

            yield return null;
        }
    }
}
