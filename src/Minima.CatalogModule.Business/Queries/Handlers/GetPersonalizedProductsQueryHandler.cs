using MediatR;
using Minima.CatalogCore.Business.Queries.Catalog;
using Minima.CatalogCore.Business.Services.Products;
using Minima.CatalogModule.Domain.Catalog;
using Minima.Infrastructure.Caching;
using Minima.Infrastructure.Caching.Constants;
using Minima.Infrastructure.Domain.Customers;
using Minima.Platform.Data;

namespace Minima.CatalogCore.Business.Queries.Handlers
{
    public class GetPersonalizedProductsQueryHandler : IRequestHandler<GetPersonalizedProductsQuery, IList<Product>>
    {

        private readonly IProductService _productService;
        private readonly ICacheBase _cacheBase;
        private readonly IRepository<CustomerProduct> _customerProductRepository;

        public GetPersonalizedProductsQueryHandler(
            IProductService productService,
            ICacheBase cacheBase,
            IRepository<CustomerProduct> customerProductRepository)
        {
            _productService = productService;
            _cacheBase = cacheBase;
            _customerProductRepository = customerProductRepository;
        }

        public async Task<IList<Product>> Handle(GetPersonalizedProductsQuery request, CancellationToken cancellationToken)
        {
            return await _cacheBase.GetAsync(string.Format(CacheKey.PRODUCTS_CUSTOMER_PERSONAL_KEY, request.CustomerId), async () =>
            {
                var query = from cr in _customerProductRepository.Table
                            where cr.CustomerId == request.CustomerId
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
