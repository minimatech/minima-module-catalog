using Minima.CatalogCore.Business.Models.Catalog;
using Minima.CatalogModule.Infrastructure.Domain.Catalog;
using Minima.Infrastructure.Mapper;
using Minima.Services.Interfaces.Common.Directory;

namespace Minima.CatalogCore.Business.Extensions;

public static class ProductsMappingExtensions
{
    public static ProductModel ToModel(this Product entity, IDateTimeService dateTimeService)
    {
        var product = entity.MapTo<Product, ProductModel>();
        product.MarkAsNewStartDateTime = entity.MarkAsNewStartDateTimeUtc.ConvertToUserTime(dateTimeService);
        product.MarkAsNewEndDateTime = entity.MarkAsNewEndDateTimeUtc.ConvertToUserTime(dateTimeService);
        product.AvailableStartDateTime = entity.AvailableStartDateTimeUtc.ConvertToUserTime(dateTimeService);
        product.AvailableEndDateTime = entity.AvailableEndDateTimeUtc.ConvertToUserTime(dateTimeService);
        //product.PreOrderDateTime = entity.PreOrderDateTimeUtc.ConvertToUserTime(dateTimeService);
        return product;

    }

    public static Product ToEntity(this ProductModel model, IDateTimeService dateTimeService)
    {
        var product = model.MapTo<ProductModel, Product>();
        product.MarkAsNewStartDateTimeUtc = model.MarkAsNewStartDateTime.ConvertToUtcTime(dateTimeService);
        product.MarkAsNewEndDateTimeUtc = model.MarkAsNewEndDateTime.ConvertToUtcTime(dateTimeService);
        product.AvailableStartDateTimeUtc = model.AvailableStartDateTime.ConvertToUtcTime(dateTimeService);
        product.AvailableEndDateTimeUtc = model.AvailableEndDateTime.ConvertToUtcTime(dateTimeService);
        //product.PreOrderDateTimeUtc = model.PreOrderDateTime.ConvertToUtcTime(dateTimeService);

        return product;
    }

    public static Product ToEntity(this ProductModel model, Product destination, IDateTimeService dateTimeService)
    {
        var product = model.MapTo(destination);
        product.MarkAsNewStartDateTimeUtc = model.MarkAsNewStartDateTime.ConvertToUtcTime(dateTimeService);
        product.MarkAsNewEndDateTimeUtc = model.MarkAsNewEndDateTime.ConvertToUtcTime(dateTimeService);
        product.AvailableStartDateTimeUtc = model.AvailableStartDateTime.ConvertToUtcTime(dateTimeService);
        product.AvailableEndDateTimeUtc = model.AvailableEndDateTime.ConvertToUtcTime(dateTimeService);
        //product.PreOrderDateTimeUtc = model.PreOrderDateTime.ConvertToUtcTime(dateTimeService);
        return product;
    }

    public static ProductAttributeValue ToEntity(this PredefinedProductAttributeValue model)
    {
        return model.MapTo<PredefinedProductAttributeValue, ProductAttributeValue>();
    }
}
