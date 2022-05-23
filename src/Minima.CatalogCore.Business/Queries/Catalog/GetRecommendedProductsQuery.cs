﻿using MediatR;
using Minima.CatalogModule.Domain.Catalog;

namespace Minima.Core.Module.Catalog.Queries.Catalog;

public class GetRecommendedProductsQuery : IRequest<IList<Product>>
{
    public string[] CustomerGroupIds { get; set; }
    public string StoreId { get; set; }
}