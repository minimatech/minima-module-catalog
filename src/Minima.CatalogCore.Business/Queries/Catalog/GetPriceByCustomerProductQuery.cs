using MediatR;

namespace Minima.Core.Module.Catalog.Queries.Catalog;

public class GetPriceByCustomerProductQuery : IRequest<double?>
{
    public string CustomerId { get; set; }
    public string ProductId { get; set; }
}