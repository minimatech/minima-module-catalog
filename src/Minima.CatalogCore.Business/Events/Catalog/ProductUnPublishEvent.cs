using MediatR;
using Minima.CatalogModule.Domain.Catalog;

namespace Minima.CatalogCore.Business.Events.Catalog;

public class ProductUnPublishEvent : INotification
{
    public ProductUnPublishEvent(Product product)
    {
        Product = product;
    }

    public Product Product { get; private set; }
}