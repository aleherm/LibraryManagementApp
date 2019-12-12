using DomainModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LibraryManagementApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Edition edition = new Edition
            {
                Id = 1,
                PageNumber = -100,
                Year = 2019,
                BookType = EBookType.EHardCover,
                Publisher = "",
                NoTotal = 10,
                NoForLibrary = 2,
                NoForLoan = 8
            };


            Borrower borrower = new Borrower()
            {
                FirstName = "a",
                LastName = "b",
                Email = "abc"
            };

            var context = new ValidationContext(borrower);
            var results = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(borrower, context, results);

            if (!isValid)
            {
                foreach (var validationResult in results)
                {
                    Console.WriteLine(validationResult.ErrorMessage);
                }
            }
        }
    }
}
