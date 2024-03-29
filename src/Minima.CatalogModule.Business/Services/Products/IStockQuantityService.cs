﻿using Minima.CatalogModule.Infrastructure.Domain.Catalog;
using Minima.Domain.Common;
using Minima.Infrastructure.Common;

namespace Minima.CatalogCore.Business.Services.Products;

public interface IStockQuantityService
{
    int GetTotalStockQuantity(Product product,
        bool useReservedQuantity = true,
        string warehouseId = "", bool total = false);

    int GetTotalStockQuantityForCombination(Product product, ProductAttributeCombination combination,
        bool useReservedQuantity = true, string warehouseId = "");

    string FormatStockMessage(Product product, string warehouseId, IList<CustomAttribute> attributes);
}
