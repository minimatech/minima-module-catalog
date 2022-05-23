using MediatR;
using Minima.CatalogModule.Domain.Catalog;

namespace Minima.CatalogCore.Business.Queries.Catalog;

public class GetProductArchByIdQuery : IRequest<Product>
{
    public string Id { get; set; }
}
