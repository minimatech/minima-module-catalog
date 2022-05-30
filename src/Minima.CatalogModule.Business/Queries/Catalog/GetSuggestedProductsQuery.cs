using MediatR;
using Minima.CatalogModule.Infrastructure.Domain.Catalog;

namespace Minima.CatalogCore.Business.Queries.Catalog;

public class GetSuggestedProductsQuery : IRequest<IList<Product>>
{
    public string[] CustomerTagIds { get; set; }
    public int ProductsNumber { get; set; }
}
