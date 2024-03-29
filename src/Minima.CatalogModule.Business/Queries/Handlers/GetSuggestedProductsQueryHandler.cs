﻿using MediatR;
using Minima.CatalogCore.Business.Queries.Catalog;
using Minima.CatalogCore.Business.Services.Products;
using Minima.CatalogModule.Infrastructure.Domain.Catalog;
using Minima.Infrastructure.Caching;
using Minima.Infrastructure.Caching.Constants;
using Minima.Infrastructure.Domain.Customers;
using Minima.Platform.Data;

namespace Minima.CatalogCore.Business.Queries.Handlers
{
    public class GetSuggestedProductsQueryHandler : IRequestHandler<GetSuggestedProductsQuery, IList<Product>>
    {
        #region Fields

        private readonly IProductService _productService;
        private readonly ICacheBase _cacheBase;
        private readonly IRepository<CustomerTagProduct> _customerTagProductRepository;

        #endregion

        public GetSuggestedProductsQueryHandler(
            IProductService productService,
            ICacheBase cacheBase,
            IRepository<CustomerTagProduct> customerTagProductRepository)
        {
            _productService = productService;
            _cacheBase = cacheBase;
            _customerTagProductRepository = customerTagProductRepository;
        }

        public async Task<IList<Product>> Handle(GetSuggestedProductsQuery request, CancellationToken cancellationToken)
        {
            return await _cacheBase.GetAsync(string.Format(CacheKey.PRODUCTS_CUSTOMER_TAG, string.Join(",", request.CustomerTagIds)), async () =>
            {
                var query = from cr in _customerTagProductRepository.Table
                            where request.CustomerTagIds.Contains(cr.CustomerTagId)
                            orderby cr.DisplayOrder
                            select cr.ProductId;

                var productIds = query.Take(request.ProductsNumber).ToList();

                var products = new List<Product>();
                var ids = await _productService.GetProductsByIds(productIds.Distinct().ToArray());
                foreach (var product in ids)
                    if (product.Published)
                        products.Add(product);

                return products;
            });

        }
    }
}
