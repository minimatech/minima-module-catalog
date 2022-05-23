using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Minima.CatalogCore.Business.Services.Categories;
using Minima.CatalogCore.Business.Services.Categories.Impl;
using Minima.CatalogCore.Business.Services.Products;
using Minima.CatalogCore.Business.Services.Products.Impl;
using Minima.CatalogModule.Api.GraphQL.Category;
using Minima.CatalogModule.Api.GraphQL.Product;
using Minima.CatalogModule.Domain.Catalog;
using Minima.GraphQL.Abstractions;
using Minima.Infrastructure;

namespace Minima.CatalogModule.Api.Startup;

public class StartupApplication : IStartupApplication
{
    public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
    {
        RegisterCatalogService(services);
        RegisterDiscountsService(services);
        RegisterTaxService(services);

        services.AddSingleton<ISchemaBuilder, CategoryMutation>();
        services.AddSingleton<ISchemaBuilder, CategoryQuery>();

        services.AddSingleton<ISchemaBuilder, ProductsQuery>();
        services.AddSingleton<ISchemaBuilder, ProductMutation>();

        services.AddInputObjectGraphType<Product, ProductInputObjectType>();
        services.AddObjectGraphType<Product, ProductQueryObjectType>();
        //services.AddObjectGraphType<ListPart, ListQueryObjectType>();
    }

    public void Configure(IApplicationBuilder application, IWebHostEnvironment webHostEnvironment)
    {
    }

    public int Priority => 100;
    public bool BeforeConfigure => false;

    private void RegisterCatalogService(IServiceCollection serviceCollection)
    {
        // serviceCollection.AddScoped<IOutOfStockSubscriptionService, OutOfStockSubscriptionService>();
        serviceCollection.AddScoped<ICategoryService, CategoryService>();
        //serviceCollection.AddScoped<IBrandService, BrandService>();
        //serviceCollection.AddScoped<IRecentlyViewedProductsService, RecentlyViewedProductsService>();
        //serviceCollection.AddScoped<ICollectionService, CollectionService>();
        //serviceCollection.AddScoped<IPriceFormatter, PriceFormatter>();
        // serviceCollection.AddScoped<IProductAttributeFormatter, ProductAttributeFormatter>();
        // serviceCollection.AddScoped<IProductAttributeParser, ProductAttributeParser>();
        // serviceCollection.AddScoped<IProductAttributeService, ProductAttributeService>();
        serviceCollection.AddScoped<IProductService, ProductService>();
        serviceCollection.AddScoped<IProductCategoryService, ProductCategoryService>();
        // serviceCollection.AddScoped<IProductCollectionService, ProductCollectionService>();
        // serviceCollection.AddScoped<IProductReviewService, ProductReviewService>();
        // serviceCollection.AddScoped<ICopyProductService, CopyProductService>();
        // serviceCollection.AddScoped<IProductReservationService, ProductReservationService>();
        // serviceCollection.AddScoped<IAuctionService, AuctionService>();
        // serviceCollection.AddScoped<IProductCourseService, ProductCourseService>();
        // serviceCollection.AddScoped<ISpecificationAttributeService, SpecificationAttributeService>();
        // serviceCollection.AddScoped<IProductLayoutService, ProductLayoutService>();
        // serviceCollection.AddScoped<IBrandLayoutService, BrandLayoutService>();
        // serviceCollection.AddScoped<ICategoryLayoutService, CategoryLayoutService>();
        // serviceCollection.AddScoped<ICollectionLayoutService, CollectionLayoutService>();
        // serviceCollection.AddScoped<IProductTagService, ProductTagService>();
        // serviceCollection.AddScoped<ICustomerGroupProductService, CustomerGroupProductService>();
        // serviceCollection.AddScoped<IInventoryManageService, InventoryManageService>();
        // serviceCollection.AddScoped<IStockQuantityService, StockQuantityService>();
        // serviceCollection.AddScoped<IPricingService, PricingService>();
        // serviceCollection.AddScoped<ISearchTermService, SearchTermService>();
        // serviceCollection.AddScoped<IGeoLookupService, GeoLookupService>();
        // serviceCollection.AddScoped<IMeasureService, MeasureService>();
    }

    private void RegisterDiscountsService(IServiceCollection serviceCollection)
    {
        //serviceCollection.AddScoped<IDiscountService, DiscountService>();
    }

    private void RegisterTaxService(IServiceCollection serviceCollection)
    {
        // serviceCollection.AddScoped<ITaxService, TaxService>();
        // serviceCollection.AddScoped<IVatService, VatService>();
        // serviceCollection.AddScoped<ITaxCategoryService, TaxCategoryService>();
    }
}