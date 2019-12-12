using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DomainModel
{
    /// <summary>
    /// Edition entity class
    /// </summary>
    public class Edition
    {
        public int Id { get; set; }

        [Range(0, 5000, ErrorMessage = ErrorMessages.PageNumberRange)]
        public int PageNumber { get; set; }
        
        public int Year { get; set; }

        public EBookType BookType { get; set; }

        [Required(ErrorMessage = ErrorMessages.PublisherRequired)]
        [MaxLength(50, ErrorMessage = ErrorMessages.PublisherMaxLength)]
        public string Publisher { get; set; }

        [Required(ErrorMessage = ErrorMessages.NoBooksForLibraryRequired)]
        public int NoForLibrary { get; set; }

        [Required(ErrorMessage = ErrorMessages.NoBooksForLoanRequired)]
        public int NoForLoan { get; set; }

        [Required(ErrorMessage = ErrorMessages.NoTotalBooksRequired)]
        public int NoTotal { get; set; }
    }
}
