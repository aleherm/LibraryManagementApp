// <copyright file="EBookType.cs" company="Transilvania University of Brasov">
// Copyright (c) Alexandra Hermeneanu. All rights reserved.
// </copyright>

namespace DomainModel
{
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Book types by cover aspect.
    /// </summary>
    [SuppressMessage("Microsoft.StyleCop.CSharp.OrderingRules", "SA1602", Justification = "Enumerations don't need to be documented.")]
    [SuppressMessage("Microsoft.StyleCop.CSharp.OrderingRules", "CS1591", Justification = "No comment needed.")]
    public enum EBookType
    {
        /// <summary>
        /// The paper back cover.
        /// </summary>
        EPaperBack,

        /// <summary>
        /// The hard cover.
        /// </summary>
        EHardCover,
    }
}
