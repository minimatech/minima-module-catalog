namespace Minima.CatalogModule.Domain.Domain.Catalog;

public partial class ProductDeleted: Product
{
    public DateTime DeletedOnUtc { get; set; }
}
