using MediatR;
using Minima.CatalogCore.Business.Events.Catalog;
using Minima.Infrastructure.Caching;
using Minima.Infrastructure.Caching.Constants;

namespace Minima.CatalogCore.Business.Events.Handlers;

public class ProductUnPublishEventHandler : INotificationHandler<ProductUnPublishEvent>
{
    private readonly ICacheBase _cacheBase;

    public ProductUnPublishEventHandler(ICacheBase cacheBase)
    {
        _cacheBase = cacheBase;
    }

    public async Task Handle(ProductUnPublishEvent notification, CancellationToken cancellationToken)
    {
        if (notification.Product.ShowOnHomePage)
            await _cacheBase.RemoveByPrefix(CacheKey.PRODUCTS_SHOWONHOMEPAGE);
    }
}