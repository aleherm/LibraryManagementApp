// <copyright file="AddressService.cs" company="Transilvania University of Brasov">
// Copyright (c) Alexandra Hermeneanu. All rights reserved.
// </copyright>

namespace Services
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using DataMapper;
    using DomainModel;

    /// <summary>
    /// Address Service class.
    /// </summary>
    public class AddressService
    {
        private readonly AddressRepository addressRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="AddressService"/> class.
        /// </summary>
        public AddressService()
        {
            addressRepository = new AddressRepository();
        }

        /// <summary>
        /// Validates the given Address object.
        /// </summary>
        /// <param name="address">The address.</param>
        /// <returns>True or False.</returns>
        public bool IsValidAddress(Address address)
        {
            ValidationContext context = new ValidationContext(address);
            IList<ValidationResult> validationResults = new List<ValidationResult>();

            return Validator.TryValidateObject(address, context, validationResults, true);
        }

        /// <summary>
        /// Inserts a new Address object in the database.
        /// </summary>
        /// <param name="address">The address.</param>
        /// <returns>True or false.</returns>
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
