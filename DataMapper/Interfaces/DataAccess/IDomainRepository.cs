// <copyright file="IDomainRepository.cs" company="Transilvania University of Brasov">
// Copyright (c) Alexandra Hermeneanu. All rights reserved.
// </copyright>

namespace DataMapper
{
    using DomainModel;

    /// <summary>
    /// The Domain Repository interface.
    /// </summary>
    /// <seealso cref="DataMapper.IRepository{DomainModel.Domain}" />
    public interface IDomainRepository : IRepository<Domain>
    {
    }
}
