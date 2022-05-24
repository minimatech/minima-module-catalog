using MediatR;
using Minima.CatalogModule.Domain.Domain.Catalog;

namespace Minima.CatalogCore.Business.Events.Catalog;

public class ProductPublishEvent : INotification
{
    public ProductPublishEvent(Product product)
    {
        Product = product;
    }

    public Product Product { get; private set; }
}
