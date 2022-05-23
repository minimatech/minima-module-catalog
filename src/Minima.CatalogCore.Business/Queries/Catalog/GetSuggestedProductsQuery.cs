using MediatR;
using Minima.CatalogModule.Domain.Catalog;

namespace Minima.Core.Module.Catalog.Queries.Catalog;

public class GetSuggestedProductsQuery : IRequest<IList<Product>>
{
    public string[] CustomerTagIds { get; set; }
    public int ProductsNumber { get; set; }
}