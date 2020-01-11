// <copyright file="LoanRepository.cs" company="Transilvania University of Brasov">
// Copyright (c) Transilvania University of Brasov. Code by Alexandra Hermeneanu. All rights reserved.
// </copyright>

namespace DataMapper
{
    using DomainModel;

    /// <summary>
    /// Data access methods for Loan.
    /// </summary>
    public class LoanRepository : BaseRepository<Loan>, ILoanRepository
    {
    }
}
