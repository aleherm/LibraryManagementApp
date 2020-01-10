using DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    interface IAddressService
    {
        bool IsValidAddress(Address address);
        bool AddNewAddress(Address address);
    }
}
