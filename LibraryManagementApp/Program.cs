using DomainModel;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Edition edition = new Edition
            {
                PageNumber = 100,
                Year = 2019,
                BookType = EBookType.EHardCover,
                Publisher = "aa",
                NoTotal = 10,
                NoForLibrary = 2,
                NoForLoan = 8
            };

            var validationResults = Validation.Validate(edition);
            if (validationResults.Count > 0)
            {
                foreach (var result in validationResults)
                {
                    Console.WriteLine("Validation error: " + result.Message);
                }
            }
            else
            {
                Console.WriteLine("The object is valid");
            }

        }
    }
}
