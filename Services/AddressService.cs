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
    public class AddressService
    {
        private AddressRepository addressRepository;

        public AddressService()
        {
            addressRepository = new AddressRepository();
        }

        private bool IsValidAddress(Address address)
        {
            ValidationContext context = new ValidationContext(address);
            IList<ValidationResult> validationResults = new List<ValidationResult>();

            return Validator.TryValidateObject(address, context, validationResults, true);
        }

        public bool AddNewAddress(string city, string street, int? number)
        {
            Address newAddress = new Address(city, street, number);
            if(IsValidAddress(newAddress))
            {
                addressRepository.Insert(newAddress);
                return true;
            }
            return false;
        }
    }
}
