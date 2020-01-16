// <copyright file="IAddressService.cs" company="Transilvania University of Brasov">
// Copyright (c) Alexandra Hermeneanu. All rights reserved.
// </copyright>

namespace Services
{
    using System.Collections.Generic;
    using DomainModel;

    /// <summary>
    /// Interface for the AddressService.
    /// </summary>
    public interface IAddressService
    {
        /// <summary>
        /// Validates the given Address object.
        /// </summary>
        /// <param name="address">The address.</param>
        /// <returns>True or False.</returns>
        bool IsValidAddress(Address address);

        /// <summary>
        /// Inserts a new Address object in the database.
        /// </summary>
        /// <param name="address">The address.</param>
        /// <returns>True or false.</returns>
        bool AddNewAddress(Address address);

        /// <summary>
        /// Gets the list of addresses.
        /// </summary>
        /// <returns>The list of addresses.</returns>
        IEnumerable<Address> GetAllAddresses();

        /// <summary>
        /// Gets the address by given ID.
        /// </summary>
        /// <param name="idAddress">The ID of the address.</param>
        /// <returns>The Address object found.</returns>
        Address GetAddressById(int idAddress);
    }
}