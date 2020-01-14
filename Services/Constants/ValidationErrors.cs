// <copyright file="ValidationErrors.cs" company="Transilvania University of Brasov">
// Copyright (c) Alexandra Hermeneanu. All rights reserved.
// </copyright>

namespace Services
{
    /// <summary>
    /// Error messages to be shown at the validation of an entity add.
    /// </summary>
    public static class ValidationErrors
    {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        public const string TooManyDomains = "The maximum number of Domains per Book have been exceeded.";
        public const string DomainAreRelated = "The given Domain are related.";
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
    }
}
