using MediatR;
using Minima.CatalogModule.Domain.Catalog;
using Minima.Core.Module.Catalog.Queries.Catalog;
using Minima.Domain.Data;

namespace Minima.CatalogCore.Business.Queries.Handlers
{
    public class GetProductArchByIdQueryHandler : IRequestHandler<GetProductArchByIdQuery, Product>
    {
        private readonly IRepository<ProductDeleted> _productDeletedRepository;

        public GetProductArchByIdQueryHandler(IRepository<ProductDeleted> productDeletedRepository)
        {
            _productDeletedRepository = productDeletedRepository;
        }

        public async Task<Product> Handle(GetProductArchByIdQuery request, CancellationToken cancellationToken)
        {
            return await _productDeletedRepository.GetByIdAsync(request.Id) as Product;
        }
    }
}
