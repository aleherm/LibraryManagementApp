using DataMapper;
using DomainModel;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Services
{
    public class AddressService : IAddressService
    {
        private AddressRepository addressRepository;

        public AddressService()
        {
            addressRepository = new AddressRepository();
        }

        public bool IsValidAddress(Address address)
        {
            ValidationContext context = new ValidationContext(address);
            IList<ValidationResult> validationResults = new List<ValidationResult>();

            return Validator.TryValidateObject(address, context, validationResults, true);
        }

        public bool AddNewAddress(Address address)
        {
            if (IsValidAddress(address))
            {
                addressRepository.Insert(address);
                return true;
            }
            return false;
        }
    }
}
