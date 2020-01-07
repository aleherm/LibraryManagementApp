using DataMapper;
using DomainModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    /// <summary>
    /// Borrower service class.
    /// </summary>
    public class BorrowerService
    {
        /// <summary>
        /// Borrower Repository
        /// </summary>
        private BorrowerRepository borrowerRepository;

        public BorrowerService()
        {
            borrowerRepository = new BorrowerRepository();
        }

        /// <summary>
        /// Validates the given data for a Borrower object.
        /// </summary>
        /// <param name="borrower"></param>
        /// <returns></returns>
        private bool IsValidBorrower(Borrower borrower)
        {
            ValidationContext context = new ValidationContext(borrower);
            IList<ValidationResult> validationResults = new List<ValidationResult>();

            return Validator.TryValidateObject(borrower, context, validationResults, true);
        }

        /// <summary>
        /// Adds new borrower if has valid data.
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="email"></param>
        /// <param name="dob"></param>
        /// <param name="readerFlg"></param>
        /// <param name="librarianFlg"></param>
        /// <returns></returns>
        public bool AddNewBorrower(string firstName, string lastName, string email, DateTime? dob, bool readerFlg, bool librarianFlg)
        {
            Borrower newBorrower = new Borrower(firstName, lastName, email, dob, readerFlg, librarianFlg);
            
            if(IsValidBorrower(newBorrower))
            {
                borrowerRepository.Insert(newBorrower);
                return true;
            }

            return false;
        }
    }
}
