namespace LibraryManagementApp
{
    using System.Diagnostics.CodeAnalysis;

    [SuppressMessage("Microsoft.StyleCop.CSharp.OrderingRules", "SA1600", Justification = "Constants don't need to be documented.")]
    public static class MenuOutput
    {
        // author
        public const string AuthorMenuTitle = "--Author Menu Entries--";
        public const string AuthorEntries = "::(NEW) Author info::";
        public const string AuthorEdit = "Edit existing author";
        public const string AuthorDelete = "Delete existing author";
        public const string AuthorShowAll = "Show all...";

        public const string AuthorFirstName = "First name: ";
        public const string AuthorLastName = "Last name: ";
        public const string AuthorLanguage = "Language: ";
        public const string AuthorDOB = "Date of birth(DD/MM/YYYY): ";
        public const string AuthorDOD = "Date of death(DD/MM/YYYY): ";

        // borrower
        public const string BorrowerMenuTitle = "--Borrower Menu Entries--";
        public const string BorrowerEntries = "::(NEW) Borrower info::";
        public const string BorrowerEdit = "Edit existing borrower";
        public const string BorrowerDelete = "Delete existing borrower";
        public const string BorrowerShowAll = "Show all...";

        public const string BorrowerFirstName = "First name: ";
        public const string BorrowerLastName = "Last name: ";
        public const string BorrowerEmail = "Email: ";
        public const string BorrowerGender = "Gender: ";
        public const string BorrowerDOB = "Date of birth (DD/MM/YYYY): ";
        public const string BorrowerAddressCity = "City: ";
        public const string BorrowerAddressStreet = "Street: ";
        public const string BorrowerAddressNumber = "Number: ";
        public const string BorrowerReader = "Is he/she a reader? (yes/no)";
        public const string BorrowerLibrarian = "Is he/she a librarian? (yes/no)";

        // book
        public const string BookMenuTitle = "--Book Menu Entries--";
        public const string BookEntries = "::(NEW) Book info::";
        public const string BookEdit = "Edit existing book";
        public const string BookDelete = "Delete existing book";
        public const string BookShowAll = "Show all books";
        public const string BookShowAllForLibrary = "Show all available books for library reading";
        public const string BookShowAllForLoan = "Show all available books for loan purposes";
        public const string BookSearch = "Search book by title";
        public const string BookTitle = "Book title: ";
        public const string BookEditions = "Edition(s): ";

        // book author(s)
        public const string BookAuthors = "Author(s): ";
        public const string AddNewAuthor = "Add new author";
        public const string AddExistingAuthor = "Add existing author(s)";
        public const string BookExistingAuthorChoice = "..Type the ID number of the author you want to add..";

        // book domain(s)
        public const string BookDomains = "Domain(s): ";
        public const string AddExistingDomain = "Add existing domain(s)";
        public const string BookExistingDomainChoice = "..Type the ID number of the domain you want to add..";
        public const string AddMoreDomains = "Add more domains? (yes/no): ";

        // book edition(s)
        public const string BookExistingEditionChoice = "..Type the ID number of the domain you want to add..";
        public const string AddMoreEditions = "Add more editions? (yes/no): ";

        // domain
        public const string DomainMenuTitle = "--Domain Menu Entries--";
        public const string DomainEntries = "::(NEW) Domain info::";

        public const string DomainName = "Domain name: ";
        public const string DomainParent = "Parent domain: ";
        public const string SubDomain = "Subdomain(s): ";

        // edition
        public const string EditionMenuTitle = "--Edition Menu Entries--";
        public const string EditionEntries = "::(NEW) Edition info::";
        public const string EditionEdit = "Edit existing edition";
        public const string EditionDelete = "Delete existing edition";
        public const string EditionShowAll = "Show all editions";

        public const string EditionPageNumber = " Page number: ";
        public const string EditionYear = " Year: ";
        public const string EditionNoForLibrary = " Number of books for library reading: ";
        public const string EditionNoForLoan = " Number of books for loan: ";
        public const string EditionPublisher = " Publisher: ";

        // general
        public const string AddNew = "Add new...";
        public const string TryAgain = " Try Again!";
        public const string Back = "Go back!";

        public const string AuthorMenuItem = "Author dashboard";
        public const string BookMenuItem = "Book dashboard";
        public const string BorrowerMenuItem = "Borrower dashboard";
        public const string DomainMenuItem = "Domain dashboard";
        public const string EditionMenuItem = "Edition dashboard";
        public const string LoanMenuItem = "Loan dashboard";

    }
}
