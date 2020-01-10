using DomainModel;
using System.Collections.Generic;

namespace Services
{
    interface IDomainService
    {
        bool IsValidDomain(Domain domain);
        bool AddNewDomain(Domain domain);
        IEnumerable<Domain> GetAllDomains();
        Domain GetDomainById(int idDomain);
    }
}
