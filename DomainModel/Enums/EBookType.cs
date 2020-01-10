namespace DomainModel
{
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Book types by cover aspect.
    /// </summary>
    [SuppressMessage("Microsoft.StyleCop.CSharp.OrderingRules", "SA1602", Justification = "Enumerations don't need to be documented.")]
    public enum EBookType
    {
        EPaperBack,
        EHardCover,
    }
}
