// <copyright file="ILoanRepository.cs" company="Transilvania University of Brasov">
// Copyright (c) Alexandra Hermeneanu. All rights reserved.
// </copyright>

namespace DataMapper
{
    using DomainModel;

    /// <summary>
    /// The Loan Repository interface.
    /// </summary>
    /// <seealso cref="DataMapper.IRepository{DomainModel.Loan}" />
    public interface ILoanRepository : IRepository<Loan>
    {
    }
}
