// <copyright file="IEditionRepository.cs" company="Transilvania University of Brasov">
// Copyright (c) Alexandra Hermeneanu. All rights reserved.
// </copyright>

namespace DataMapper
{
    using DomainModel;

    /// <summary>
    /// The Edition Repository interface.
    /// </summary>
    /// <seealso cref="DataMapper.IRepository{DomainModel.Edition}" />
    public interface IEditionRepository : IRepository<Edition>
    {
    }
}
