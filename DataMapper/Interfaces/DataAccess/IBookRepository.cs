// <copyright file="IBookRepository.cs" company="Transilvania University of Brasov">
// Copyright (c) Alexandra Hermeneanu. All rights reserved.
// </copyright>

namespace DataMapper
{
    using DomainModel;

    /// <summary>
    /// The Book Repository interface.
    /// </summary>
    /// <seealso cref="DataMapper.IRepository{DomainModel.Book}" />
    public interface IBookRepository : IRepository<Book>
    {
    }
}
