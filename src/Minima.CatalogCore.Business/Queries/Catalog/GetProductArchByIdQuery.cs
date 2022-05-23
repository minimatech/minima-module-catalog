using MediatR;
using Minima.CatalogModule.Domain.Catalog;

namespace Minima.Core.Module.Catalog.Queries.Catalog;

public class GetProductArchByIdQuery : IRequest<Product>
{
    public string Id { get; set; }
}