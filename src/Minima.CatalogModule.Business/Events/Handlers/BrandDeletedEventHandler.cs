using MediatR;
using Minima.CatalogModule.Domain.Catalog;
using Minima.Infrastructure.Events;
using Minima.Platform.Data;

namespace Minima.CatalogCore.Business.Events.Handlers;

public class BrandDeletedEventHandler : INotificationHandler<EntityDeleted<Brand>>
{
    private readonly IRepository<Product> _productRepository;

    public BrandDeletedEventHandler(IRepository<Product> productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task Handle(EntityDeleted<Brand> notification, CancellationToken cancellationToken)
    {
        await _productRepository.UpdateManyAsync(x => x.BrandId == notification.Entity.Id,
            UpdateBuilder<Product>.Create().Set(x => x.BrandId, ""));
    }
}