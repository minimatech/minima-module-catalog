﻿using Minima.Domain;

namespace Minima.CatalogModule.Domain.Catalog;

public class ProductPrice : SubBaseEntity
{
    public string ProductId { get; set; }
    public string CurrencyCode { get; set; }
    public double Price { get; set; }
}