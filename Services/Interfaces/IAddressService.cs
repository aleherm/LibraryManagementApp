// <copyright file="IAddressService.cs" company="Transilvania University of Brasov">
// Copyright (c) Alexandra Hermeneanu. All rights reserved.
// </copyright>

namespace Services
{
    using DomainModel;

    /// <summary>
    /// Interface for the AddressService.
    /// </summary>
    internal interface IAddressService
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
    }
}
