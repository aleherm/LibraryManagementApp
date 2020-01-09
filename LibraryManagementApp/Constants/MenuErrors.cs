using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementApp
{
    public static class MenuErrors
    {
        public static string InvalidInputError = "Invalid input.";
        public static string WrongInputFormatError = "Wrong input format.";

        public static string FailedBorrowerInsert = "Could not add the new borrower with the given data.";
        public static string FailedBookInsert = "Could not add the new book with the given data.";
        public static string FailedLoanInsert = "Could not add the new loan with the given data.";
        public static string FailedDomainInsert = "Could not add the new domain with the given data.";
        public static string FailedEditionInsert = "Could not add the new edition with the given data.";

        public static string FailedDomainGet = "The domain with the given ID doesn't exist";
        public static string FailedAuthorGet = "The author with the given ID doesn't exist";
    }
}
