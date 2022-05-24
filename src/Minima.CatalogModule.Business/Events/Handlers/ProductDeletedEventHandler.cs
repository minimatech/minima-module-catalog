﻿using MediatR;
using Minima.CatalogCore.Business.Services.Products;
using Minima.Infrastructure.Domain.Customers;
using Minima.Infrastructure.Events;
using Minima.Platform.Data;
using System.Text.Json;
using Minima.CatalogModule.Domain.Domain.Catalog;

namespace Minima.CatalogCore.Business.Events.Handlers;

public class ProductDeletedEventHandler : INotificationHandler<EntityDeleted<Product>>
{
    private readonly IRepository<Product> _productRepository;
    private readonly IRepository<CustomerGroupProduct> _customerGroupProductRepository;
    private readonly IRepository<Customer> _customerRepository;
    private readonly IRepository<ProductTag> _productTagRepository;
    private readonly IRepository<ProductReview> _productReviewRepository;
    private readonly IRepository<ProductDeleted> _productDeletedRepository;
    private readonly IProductTagService _productTagService;

    public ProductDeletedEventHandler(
        IRepository<Product> productRepository,
        IRepository<CustomerGroupProduct> customerGroupProductRepository,
        IRepository<Customer> customerRepository,
        IRepository<ProductTag> productTagRepository,
        IRepository<ProductReview> productReviewRepository,
        IRepository<ProductDeleted> productDeletedRepository,
        IProductTagService productTagService)
    {
        _productRepository = productRepository;
        _customerGroupProductRepository = customerGroupProductRepository;
        _customerRepository = customerRepository;
        _productTagRepository = productTagRepository;
        _productReviewRepository = productReviewRepository;
        _productDeletedRepository = productDeletedRepository;
        _productTagService = productTagService;
    }

    public async Task Handle(EntityDeleted<Product> notification, CancellationToken cancellationToken)
    {
        //delete related product
        await _productRepository.PullFilter(string.Empty, x => x.RelatedProducts, z => z.ProductId2, notification.Entity.Id);

        //delete similar product
        await _productRepository.PullFilter(string.Empty, x => x.SimilarProducts, z => z.ProductId2, notification.Entity.Id);

        //delete cross sales product
        await _productRepository.Pull(string.Empty, x => x.CrossSellProduct, notification.Entity.Id);

        //delete recomended product
        await _productRepository.Pull(string.Empty, x => x.RecommendedProduct, notification.Entity.Id);

        //delete review
        await _productReviewRepository.DeleteManyAsync(x=>x.ProductId == notification.Entity.Id);

        //delete customer group product
        await _customerGroupProductRepository.DeleteManyAsync(x => x.ProductId == notification.Entity.Id);

        //delete product tags
        var existingProductTags = _productTagRepository.Table.Where(x => notification.Entity.ProductTags.ToList().Contains(x.Name)).ToList();
        foreach (var tag in existingProductTags)
        {
            await _productTagService.DetachProductTag(tag, notification.Entity.Id);
        }

        //insert to deleted products
        var productDeleted = JsonSerializer.Deserialize<ProductDeleted>(JsonSerializer.Serialize(notification.Entity));
        productDeleted.DeletedOnUtc = DateTime.UtcNow;
        await _productDeletedRepository.InsertAsync(productDeleted);

    }
}
