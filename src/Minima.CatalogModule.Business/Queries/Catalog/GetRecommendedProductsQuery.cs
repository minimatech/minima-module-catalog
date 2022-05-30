using MediatR;
using Minima.CatalogModule.Infrastructure.Domain.Catalog;

namespace Minima.CatalogCore.Business.Queries.Catalog;

public class GetRecommendedProductsQuery : IRequest<IList<Product>>
{
    public string[] CustomerGroupIds { get; set; }
    public string StoreId { get; set; }
}
