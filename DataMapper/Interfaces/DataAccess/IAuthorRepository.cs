// <copyright file="IAuthorRepository.cs" company="Transilvania University of Brasov">
// Copyright (c) Alexandra Hermeneanu. All rights reserved.
// </copyright>

namespace DataMapper
{
    using DomainModel;

    /// <summary>
    /// The Author Repository interface.
    /// </summary>
    /// <seealso cref="DataMapper.IRepository{DomainModel.Author}" />
    public interface IAuthorRepository : IRepository<Author>
    {
    }
}
