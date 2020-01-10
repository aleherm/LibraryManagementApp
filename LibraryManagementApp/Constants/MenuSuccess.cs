namespace LibraryManagementApp
{
    using System.Diagnostics.CodeAnalysis;

    [SuppressMessage("Microsoft.StyleCop.CSharp.OrderingRules", "SA1600", Justification = "Constants don't need to be documented.")]
    public static class MenuSuccess
    {
        // add
        public const string BorrowerAddSuccess = "New borrower with address added successfuly!";
        public const string BookAddSuccess = "New book with authors, domains and editions added successfuly!";
        public const string AuthorAddSuccess = "New author added successfuly!";
        public const string DomainAddSuccess = "New domain added successfuly!";
        public const string EditionAddSuccess = "New edition added successfuly!";
        public const string LoanAddSuccess = "New loan added successfuly!";
        public const string BookAuthorAddSuccess = "New author(s) added successfuly!";
        public const string BookDomainAddSuccess = "New domain(s) added successfuly!";

        // saved
        public const string BookAuthorSavedInputs = "New author's data is saved";
        public const string BookDomainSavedInputs = "New domain's data is saved";
        public const string BookSubomainSavedInputs = "New subdomain's data is saved";

        // info
        public const string CheckAuthorList = "To add the new author to the book check the existing list of authors and add it from there.";

    }
}
