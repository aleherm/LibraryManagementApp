using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    public static class ErrorMessages
    {
        // Required
        public const string AuthorFirstNameRequired = "The author's First Name must be provided.";
        public const string AuthorLastNameRequired = "The author's Last Name must be provided.";
        public const string BorrowerFirstNameRequired = "The borrower's First Name must be provided.";
        public const string BorrowerLastNameRequired = "The borrower's Last Name must be provided.";
        public const string EmailRequired = "The borrower's Email must be provided";
        public const string DomainNameRequired = "The Domain Name must be provided";
        public const string NoBooksForLibraryRequired = "The Number of Books available for library reading must be provided";
        public const string NoBooksForLoanRequired = "The Number of Books available for loan purposes must be provided";
        public const string NoTotalBooksRequired = "The Total Number of books must be provided";
        public const string LoanDateRequired = "The Loan Date must be provided";
        public const string PublisherRequired = "The Publisher Name must be provided.";

        public const string LoanRequired = "The Loan list cannot be null.";
        public const string ReaderFlagRequired = "The Reader Flag cannot be null.";
        public const string LibrarianFlagRequired = "The Librarian Flag cannot be null.";

        // Length
        public const string FirstNameMaxLength = "The First Name must have less that 50 characters.";
        public const string LastNameMaxLength = "The Last Name must have less that 50 characters.";
        public const string EmailMaxLength = "The borrower's email must have less than 50 characters";
        public const string DomainMaxLength = "The Domain Name must have less than 100 characters";
        public const string PublisherMaxLength = "The Publisher name must have less than 50 characters.";

        // Range
        public const string PageNumberRange = "The Page Number must be between 0 an 5000.";

    }
}
