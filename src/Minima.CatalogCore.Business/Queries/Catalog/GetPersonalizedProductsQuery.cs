using MediatR;
using Minima.CatalogModule.Domain.Catalog;

namespace Minima.Core.Module.Catalog.Queries.Catalog;

public class GetPersonalizedProductsQuery : IRequest<IList<Product>>
{
    public string CustomerId { get; set; }
    public int ProductsNumber { get; set; }
}