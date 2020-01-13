// <copyright file="EGenderType.cs" company="Transilvania University of Brasov">
// Copyright (c) Transilvania University of Brasov. Code by Alexandra Hermeneanu. All rights reserved.
// </copyright>

namespace DomainModel
{
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// The gender of a borrower.
    /// </summary>
    [SuppressMessage("Microsoft.StyleCop.CSharp.OrderingRules", "SA1602", Justification = "Enumerations don't need to be documented.")]
    [SuppressMessage("Microsoft.StyleCop.CSharp.OrderingRules", "CS1591", Justification = "No comment needed.")]
    public enum EGenderType
    {
        /// <summary>
        /// The female gender.
        /// </summary>
        EFemale,

        /// <summary>
        /// The male gender
        /// </summary>
        EMale,
    }
}
