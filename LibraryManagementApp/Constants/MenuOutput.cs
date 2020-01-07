using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementApp
{
    public static class MenuOutput
    {
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
        public static string BookShowAll = "Show all...";
        public static string BookTitle = "Book title: ";

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
