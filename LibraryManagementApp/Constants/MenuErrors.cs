namespace LibraryManagementApp
{
    using System.Diagnostics.CodeAnalysis;

    [SuppressMessage("Microsoft.StyleCop.CSharp.OrderingRules", "SA1600", Justification = "Constants don't need to be documented.")]
    public static class MenuErrors
    {
        public const string InvalidInputError = "Invalid input.";
        public const string WrongInputFormatError = "Wrong input format.";

        public const string FailedBorrowerInsert = "Could not add the new borrower with the given data.";
        public const string FailedBookInsert = "Could not add the new book with the given data.";
        public const string FailedLoanInsert = "Could not add the new loan with the given data.";
        public const string FailedDomainInsert = "Could not add the new domain with the given data.";
        public const string FailedEditionInsert = "Could not add the new edition with the given data.";

        public const string FailedDomainGet = "The domain with the given ID doesn't exist";
        public const string FailedAuthorGet = "The author with the given ID doesn't exist";
    }
}
