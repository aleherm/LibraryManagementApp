using DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    interface IEditionService
    {
        bool IsValidEdition(Edition edition);
        bool AddNewEdition(Edition edition);
        Edition GetEditionById(int idEdition);
        IEnumerable<Edition> GetAllEditions();
    }
}
