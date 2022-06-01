using GraphQL;
using GraphQL.Types;
using Microsoft.Extensions.DependencyInjection;
using Minima.CatalogCore.Business.Services.Brands;
using Minima.CatalogCore.Business.Services.Categories;
using Minima.CatalogModule.Api.GraphQL.Brand.Types;
using Minima.CatalogModule.Api.GraphQL.Category.Types;
using Minima.Infrastructure;
using Minima.Platform.GraphQL.Abstractions;
using Minima.Platform.GraphQL.Abstractions.Resolvers;

namespace Minima.CatalogModule.Api.GraphQL.Brand.Fields.Query;

public class GetAllBrandsQuery : IQueryFieldMarker
{

    public async Task BuildQueryFields(ISchema schema)
    {
        var getAllCategoriesFieldType = new FieldType
        {
            Name = "getAllBrands",
            Type = typeof(ListGraphType<BrandType>),
            Resolver = new LockedAsyncFieldResolver<IPagedList<Infrastructure.Domain.Catalog.Brand>>(ResolveAsync),
            Arguments = new QueryArguments(
                new QueryArgument<IntGraphType> {Name = "pageIndex", Description = "Page Index", DefaultValue = 0},
                new QueryArgument<IntGraphType>
                    {Name = "pageSize", Description = "Page Size", DefaultValue = int.MaxValue,},
                new QueryArgument<StringGraphType>
                    {Name = "brandName", Description = "Brand name", DefaultValue = ""},
                new QueryArgument<BooleanGraphType>
                    {Name = "showHidden", Description = "Show Hidden Brands", DefaultValue = false}
            )
        };
        schema.Query.AddField(getAllCategoriesFieldType);
    }

    private async Task<IPagedList<Infrastructure.Domain.Catalog.Brand>> ResolveAsync(
        IResolveFieldContext resolveContext)
    {
        var brandService = resolveContext?.RequestServices?.GetService<IBrandService>();

        var pageIndex = resolveContext?.GetArgument<int>("pageIndex");
        var pageSize = resolveContext?.GetArgument<int>("pageSize");
        var brandName = resolveContext?.GetArgument<string>("brandName");
        var showHidden = resolveContext?.GetArgument<bool>("showHidden");

        var categories = await brandService?.GetAllBrands(
            pageIndex: pageIndex!.Value,
            pageSize: pageSize!.Value,
            brandName: brandName,
            showHidden: showHidden!.Value
        )!;
        return categories;
    }

}
