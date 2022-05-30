using MediatR;
using Minima.CatalogModule.Infrastructure.Domain.Catalog;
using Minima.Infrastructure.Caching;
using Minima.Infrastructure.Caching.Constants;
using Minima.Infrastructure.Events;
using Minima.Platform.Data;

namespace Minima.CatalogCore.Business.Events.Handlers;

public class CollectionDeletedEventHandler : INotificationHandler<EntityDeleted<Collection>>
{
    private readonly IRepository<Product> _productRepository;
    private readonly ICacheBase _cacheBase;

    public CollectionDeletedEventHandler(
        IRepository<Product> productRepository,
        ICacheBase cacheBase)
    {
        _productRepository = productRepository;
        _cacheBase = cacheBase;
    }

    public async Task Handle(EntityDeleted<Collection> notification, CancellationToken cancellationToken)
    {
        //delete on the product
        await _productRepository.PullFilter(string.Empty, x => x.ProductCollections, z => z.CollectionId, notification.Entity.Id);

        //clear cache
        await _cacheBase.RemoveByPrefix(CacheKey.PRODUCTS_PATTERN_KEY);

    }
}
