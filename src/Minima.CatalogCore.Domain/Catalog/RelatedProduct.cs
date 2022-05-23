using Minima.Domain;

namespace Minima.CatalogModule.Domain.Catalog;

/// <summary>
/// Represents a related product
/// </summary>
public partial class RelatedProduct : SubBaseEntity
{
    /// <summary>
    /// Gets or sets the second product identifier
    /// </summary>
    public string ProductId2 { get; set; }
    /// <summary>
    /// Gets or sets the display order
    /// </summary>
    public int DisplayOrder { get; set; }
}