using Minima.Infrastructure.Domain;

namespace Minima.CatalogModule.Domain.Domain.Catalog;

public partial class RecentlyViewedProduct: BaseEntity
{
    public string CustomerId { get; set; }
    public string ProductId { get; set; }
    public DateTime CreatedOnUtc { get; set; }

}
