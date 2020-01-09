using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementApp
{
    public static class MenuOutput
    {
        // author 
        public static string AuthorMenuTitle = "--Author Menu Entries--";
        public static string AuthorEntries = "::(NEW) Author info::";
        public static string AuthorEdit = "Edit existing author";
        public static string AuthorDelete = "Delete existing author";
        public static string AuthorShowAll = "Show all...";

        public static string AuthorFirstName = "First name: ";
        public static string AuthorLastName = "Last name: ";
        public static string AuthorLanguage = "Language: ";
        public static string AuthorDOB = "Date of birth(DD/MM/YYYY): ";
        public static string AuthorDOD = "Date of death(DD/MM/YYYY): ";

        // borrower
        public static string BorrowerMenuTitle = "--Borrower Menu Entries--";
        public static string BorrowerEntries = "::(NEW) Borrower info::";
        public static string BorrowerEdit = "Edit existing borrower";
        public static string BorrowerDelete = "Delete existing borrower";
        public static string BorrowerShowAll = "Show all...";

        public static string BorrowerFirstName = "First name: ";
        public static string BorrowerLastName = "Last name: ";
        public static string BorrowerEmail = "Email: ";
        public static string BorrowerGender = "Gender: ";
        public static string BorrowerDOB = "Date of birth (DD/MM/YYYY): ";
        public static string BorrowerAddressCity = "City: ";
        public static string BorrowerAddressStreet = "Street: ";
        public static string BorrowerAddressNumber = "Number: ";
        public static string BorrowerReader = "Is he/she a reader? (yes/no)";
        public static string BorrowerLibrarian = "Is he/she a librarian? (yes/no)";

        // book
        public static string BookMenuTitle = "--Book Menu Entries--";
        public static string BookEntries = "::(NEW) Book info::";
        public static string BookEdit = "Edit existing book";
        public static string BookDelete = "Delete existing book";
        public static string BookShowAll = "Show all books";
        public static string BookShowAllForLibrary = "Show all available books for library reading";
        public static string BookShowAllForLoan = "Show all available books for loan purposes";
        public static string BookSearch = "Search book by title";
        public static string BookTitle = "Book title: ";
        public static string BookEditions = "Edition(s): ";

        // book author(s)
        public static string BookAuthors = "Author(s): ";
        public static string AddNewAuthor = "Add new author";
        public static string AddExistingAuthor = "Add existing author(s)";
        public static string BookExistingAuthorChoice = "..Type the ID number of the author you want to add..";

        // book domain(s)
        public static string BookDomains = "Domain(s): ";
        public static string AddExistingDomain = "Add existing domain(s)";
        public static string BookExistingDomainChoice = "..Type the ID number of the domain you want to add..";
        public static string AddMoreDomains = "Add more domains? (yes/no): ";

        // book edition(s)
        public static string BookExistingEditionChoice = "..Type the ID number of the domain you want to add..";
        public static string AddMoreEditions = "Add more editions? (yes/no): ";

        // domain
        public static string DomainMenuTitle = "--Domain Menu Entries--";
        public static string DomainEntries = "::(NEW) Domain info::";

        public static string DomainName = "Domain name: ";
        public static string DomainParent = "Parent domain: ";
        public static string SubDomain = "Subdomain(s): ";

        // edition
        public static string EditionMenuTitle = "--Edition Menu Entries--";
        public static string EditionEntries = "::(NEW) Edition info::";
        public static string EditionEdit = "Edit existing edition";
        public static string EditionDelete = "Delete existing edition";
        public static string EditionShowAll = "Show all editions";

        public static string EditionPageNumber = " Page number: ";
        public static string EditionYear = " Year: ";
        public static string EditionNoForLibrary = " Number of books for library reading: ";
        public static string EditionNoForLoan = " Number of books for loan: ";
        public static string EditionPublisher = " Publisher: ";

        // general
        public static string AddNew = "Add new...";
        public static string TryAgain = " Try Again!";
        public static string Back = "Go back!";

        public static string AuthorMenuItem = "Author dashboard";
        public static string BookMenuItem = "Book dashboard";
        public static string BorrowerMenuItem = "Borrower dashboard";
        public static string DomainMenuItem = "Domain dashboard";
        public static string EditionMenuItem = "Edition dashboard";
        public static string LoanMenuItem = "Loan dashboard";

    }
}
