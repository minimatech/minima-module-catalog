using MediatR;
using Minima.CatalogModule.Domain.Catalog;
using Minima.Infrastructure.Caching;
using Minima.Infrastructure.Caching.Constants;
using Minima.Infrastructure.Events;
using Minima.Platform.Data;

namespace Minima.CatalogCore.Business.Events.Handlers;

public class CategoryDeletedEventHandler : INotificationHandler<EntityDeleted<Category>>
{
    private readonly IRepository<Product> _productRepository;

    private readonly ICacheBase _cacheBase;

    public CategoryDeletedEventHandler(IRepository<Product> productRepository,
        ICacheBase cacheBase)
    {
        _productRepository = productRepository;

        _cacheBase = cacheBase;
    }

    public async Task Handle(EntityDeleted<Category> notification, CancellationToken cancellationToken)
    {
            
        //delete on the product
        await _productRepository.PullFilter(string.Empty, x => x.ProductCategories, z => z.CategoryId, notification.Entity.Id);

        //clear cache
        await _cacheBase.RemoveByPrefix(CacheKey.PRODUCTS_PATTERN_KEY);

    }
}