using MediatR;
using Minima.CatalogModule.Domain.Catalog;

namespace Minima.CatalogCore.Business.Events.Catalog;

public class UpdateStockEvent : INotification
{
    private readonly Product _product;

    public UpdateStockEvent(Product product)
    {
        _product = product;
    }

    public Product Result { get { return _product; } }
}