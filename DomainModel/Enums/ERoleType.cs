// <copyright file="ERoleType.cs" company="Transilvania University of Brasov">
// Copyright (c) Alexandra Hermeneanu. All rights reserved.
// </copyright>

namespace DomainModel
{
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// The roles types of a borrower.
    /// </summary>
    [SuppressMessage("Microsoft.StyleCop.CSharp.OrderingRules", "SA1602", Justification = "Enumerations don't need to be documented.")]
    [SuppressMessage("Microsoft.StyleCop.CSharp.OrderingRules", "CS1591", Justification = "No comment needed.")]
    public enum ERoleType
    {
        /// <summary>
        /// The reader flag.
        /// </summary>
        EReader,

        /// <summary>
        /// The librarian flag.
        /// </summary>
        ELibrarian,
    }
}
