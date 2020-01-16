// <copyright file="IBorrowerRepository.cs" company="Transilvania University of Brasov">
// Copyright (c) Alexandra Hermeneanu. All rights reserved.
// </copyright>

namespace DataMapper
{
    using DomainModel;

    /// <summary>
    /// The Borrower Repository interface.
    /// </summary>
    /// <seealso cref="DataMapper.IRepository{DomainModel.Borrower}" />
    public interface IBorrowerRepository : IRepository<Borrower>
    {
    }
}
