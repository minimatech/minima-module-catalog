using MediatR;
using Minima.CatalogModule.Domain.Catalog;

namespace Minima.CatalogCore.Business.Queries.Catalog;

public class GetPersonalizedProductsQuery : IRequest<IList<Product>>
{
    public string CustomerId { get; set; }
    public int ProductsNumber { get; set; }
}
