using MediatR;
using Minima.CatalogCore.Business.Services.Products;
using Minima.CatalogModule.Domain.Catalog;
using Minima.Core.Module.Catalog.Queries.Catalog;
using Minima.Domain.Customers;
using Minima.Domain.Data;
using Minima.Infrastructure.Caching;
using Minima.Infrastructure.Caching.Constants;

namespace Minima.CatalogCore.Business.Queries.Handlers
{
    public class GetRecommendedProductsQueryHandler : IRequestHandler<GetRecommendedProductsQuery, IList<Product>>
    {

        private readonly IProductService _productService;
        private readonly ICacheBase _cacheBase;
        private readonly IRepository<CustomerGroupProduct> _customerGroupProductRepository;

        public GetRecommendedProductsQueryHandler(
            IProductService productService,
            ICacheBase cacheBase,
            IRepository<CustomerGroupProduct> customerGroupProductRepository)
        {
            _productService = productService;
            _cacheBase = cacheBase;
            _customerGroupProductRepository = customerGroupProductRepository;
        }

        public async Task<IList<Product>> Handle(GetRecommendedProductsQuery request, CancellationToken cancellationToken)
        {
            return await _cacheBase.GetAsync(string.Format(CacheKey.PRODUCTS_CUSTOMER_GROUP, string.Join(",", request.CustomerGroupIds), request.StoreId), async () =>
            {
                var query = from cr in _customerGroupProductRepository.Table
                            where request.CustomerGroupIds.Contains(cr.CustomerGroupId)
                            orderby cr.DisplayOrder
                            select cr.ProductId;

                var productIds = query.ToList();

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
