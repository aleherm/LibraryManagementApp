// <copyright file="ErrorMessages.cs" company="Transilvania University of Brasov">
// Copyright (c) Alexandra Hermeneanu. All rights reserved.
// </copyright>

namespace DomainModel
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public static class ErrorMessages
    {
        // Required
        public const string BookTitleRequired = "The Book Title must be provided.";
        public const string BorrowerFirstNameRequired = "The borrower's FirstName must be provided.";
        public const string BorrowerLastNameRequired = "The borrower's LastName must be provided.";
        public const string CityNameRequired = "The City name must be provided.";
        public const string DomainNameRequired = "The DomainName must be provided";
        public const string EmailRequired = "The borrower's Email must be provided";
        public const string FirstNameRequired = "The person's First Name must be provided.";
        public const string HouseNumberRequired = "The house Number must be provided.";
        public const string LanguageRequired = "The Language must be provided.";
        public const string LastNameRequired = "The person's Last Name must be provided.";
        public const string LoanDateRequired = "The LoanDate must be provided";
        public const string NoBooksForLibraryRequired = "The NoBooks available for library reading must be provided";
        public const string NoBooksForLoanRequired = "The NoBooks available for loan purposes must be provided";
        public const string NoTotalBooksRequired = "The NoTotal of books must be provided";
        public const string PublisherRequired = "The PublisherName must be provided.";
        public const string StreetNameRequired = "The Street name must be provided.";

        public const string AuthorRequired = "The Author list cannot be null.";
        public const string DomainRequired = "The Domain list cannot be null.";
        public const string LoanRequired = "The Loan list cannot be null.";
        public const string EditionRequired = "The Edition list cannot be null.";
        public const string ReaderFlagRequired = "The ReaderFlag cannot be null.";
        public const string LibrarianFlagRequired = "The LibrarianFlag cannot be null.";
        public const string SubdomainRequired = "The Subdomain list cannot be null.";

        public const string ListRequireAtLeastOneObject = "The list must have at least one object.";
        public const string AuthorsListRequireAtLeastOneObject = "The Authors list must have at least one object of type Author.";
        public const string DomainsListRequireAtLeastOneObject = "The Domains list must have at least one object of type Domain.";
        public const string EditionsListRequireAtLeastOneObject = "The Editions list must have at least one object of type Edition.";

        // Length
        public const string BookTitleRangeLength = "The Book Title must have between 2 and 100 characters.";
        public const string FirstNameRangeLength = "The person's First Name must have between 2 and 50 characters.";
        public const string LastNameRangeLength = "The person's Last Name must have between 2 and 50 characters.";
        public const string EmailMaxLength = "The borrower's Email must have less than 50 characters";
        public const string DomainNameRangeLength = "The DomainName must have between 5 and 100 characters";
        public const string PublisherRangeLength = "The Publisher must have between 3 and 50 characters.";
        public const string StreetLength = "The Street name must have between 2 and 50 characters.";
        public const string LanguageRangeLength = "The Language name must have between 2 and 50 characters.";

        // Range
        public const string PageNumberRange = "The PageNumber must be between 5 an 5000.";
        public const string HouseNumberRange = "The Number of the house must be between 1 an 5000.";
        public const string CityRangeLength = "The City name must have between 5 and 50 characters.";

        public const string LibraryBooksRangeNumber = "The number of books for library must be  between 0 and 50.";
        public const string LoanBooksRangeNumber = "The number of books for loan must be  between 0 and 50.";
        public const string TotalBooksRangeNumber = "The total number of books must be  between 0 and 100.";

        // other
        public const string InvalidDate = "Invalid date";
        public const string InvalidEmail = "Invalid email";
        public const string InvalidYear = "Invalid year";
        public const string InvalidNumber = "Invalid number";
        public const string InvalidData = "Invalid data";
        public static string NegativeThreshold = "Negative threshold";
    }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}
