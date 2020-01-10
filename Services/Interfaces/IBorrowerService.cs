using DomainModel;
using System.Collections.Generic;

namespace Services
{
    interface IBorrowerService
    {
        bool IsValidBorrower(Borrower borrower);
        bool AddNewBorrower(Borrower borrower);
        IEnumerable<Borrower> GetAllBorrowers();
        Borrower GetBorrowerById(int idBorrower);
    }
}
