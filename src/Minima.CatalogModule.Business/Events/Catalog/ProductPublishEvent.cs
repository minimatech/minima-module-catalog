using MediatR;
using Minima.CatalogModule.Infrastructure.Domain.Catalog;

namespace Minima.CatalogCore.Business.Events.Catalog;

public class ProductPublishEvent : INotification
{
    public ProductPublishEvent(Product product)
    {
        Product = product;
    }

    public Product Product { get; private set; }
}
