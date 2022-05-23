using MediatR;

namespace Minima.CatalogCore.Business.Queries.Catalog;

public class GetPriceByCustomerProductQuery : IRequest<double?>
{
    public string CustomerId { get; set; }
    public string ProductId { get; set; }
}