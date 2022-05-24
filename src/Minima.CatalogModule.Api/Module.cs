using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Minima.CatalogCore.Business.Services.Categories;
using Minima.CatalogCore.Business.Services.Categories.Impl;
using Minima.CatalogCore.Business.Services.Products;
using Minima.CatalogCore.Business.Services.Products.Impl;
using Minima.CatalogModule.Api.GraphQL.Category;
using Minima.CatalogModule.Api.GraphQL.Product;
using Minima.CatalogModule.Domain.Domain.Catalog;
using Minima.GraphQL.Abstractions;
using Minima.Infrastructure.Modularity;


namespace Minima.CatalogModule.Api;

public class Module : IModule
{
    private IApplicationBuilder _applicationBuilder;



    public ManifestModuleInfo ModuleInfo { get; set; }


    public void Initialize(IServiceCollection serviceCollection)
    {
        RegisterCatalogService(serviceCollection);
        RegisterDiscountsService(serviceCollection);
        RegisterTaxService(serviceCollection);

        // serviceCollection.AddSingleton<ISchemaBuilder, CategoryMutation>();
        // serviceCollection.AddSingleton<ISchemaBuilder, CategoryQuery>();

        // serviceCollection.AddSingleton<ISchemaBuilder, ProductsQuery>();
        // serviceCollection.AddSingleton<ISchemaBuilder, ProductMutation>();

        serviceCollection.AddInputObjectGraphType<Product, ProductInputObjectType>();
        serviceCollection.AddObjectGraphType<Product, ProductQueryObjectType>();
        //services.AddObjectGraphType<ListPart, ListQueryObjectType>();
    }

    public void PostInitialize(IApplicationBuilder appBuilder)
    {

    }

    public void Uninstall()
    {

    }

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
