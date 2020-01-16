// <copyright file="IAddressRepository.cs" company="Transilvania University of Brasov">
// Copyright (c) Alexandra Hermeneanu. All rights reserved.
// </copyright>

namespace DataMapper
{
    using DomainModel;

    /// <summary>
    /// The Address Repository interface.
    /// </summary>
    /// <seealso cref="DataMapper.IRepository{DomainModel.Address}" />
    public interface IAddressRepository : IRepository<Address>
    {
    }
}
