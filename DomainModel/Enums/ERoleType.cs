namespace DomainModel
{
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// The roles types of a borrower.
    /// </summary>
    [SuppressMessage("Microsoft.StyleCop.CSharp.OrderingRules", "SA1602", Justification = "Enumerations don't need to be documented.")]
    public enum ERoleType
    {
        EReader,
        ELibrarian,
    }
}
