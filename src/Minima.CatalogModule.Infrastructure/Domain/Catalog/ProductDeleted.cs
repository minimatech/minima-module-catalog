namespace Minima.CatalogModule.Infrastructure.Domain.Catalog;

public partial class ProductDeleted: Product
{
    public DateTime DeletedOnUtc { get; set; }
}
