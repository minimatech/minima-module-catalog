using GraphQL;
using GraphQL.Types;
using Microsoft.Extensions.DependencyInjection;
using Minima.CatalogCore.Business.Services.Categories;
using Minima.CatalogModule.Api.GraphQL.Category.Types;
using Minima.GraphQL.Abstractions;
using Minima.GraphQL.Abstractions.Resolvers;
using Minima.Infrastructure;

namespace Minima.CatalogModule.Api.GraphQL.Category.Fields.Query;

public class GetAllCategoriesQuery : IQueryFieldMarker
{
    private readonly ISchemaFactory _schemaFactory;

    public GetAllCategoriesQuery(ISchemaFactory schemaFactory)
    {
        _schemaFactory = schemaFactory;

    }
    public async Task BuildQueryFields()
    {
        var schema = await _schemaFactory.GetSchemaAsync();
        var getAllCategoriesFieldType = new FieldType
        {
            Name = "getAllCategories",
            Type = typeof(ListGraphType<CategoryType>),
            Resolver = new LockedAsyncFieldResolver<IPagedList<Domain.Catalog.Category>>(ResolveAsync),
            Arguments = new QueryArguments(
                new QueryArgument<IntGraphType> {Name = "pageIndex", Description = "Page Index", DefaultValue = 0},
                new QueryArgument<IntGraphType>
                    {Name = "pageSize", Description = "Page Size", DefaultValue = int.MaxValue,},
                new QueryArgument<StringGraphType>
                    {Name = "categoryName", Description = "Category name", DefaultValue = ""},
                new QueryArgument<StringGraphType>
                    {Name = "parentId", Description = "Category parent id", DefaultValue = ""},
                new QueryArgument<BooleanGraphType>
                    {Name = "showHidden", Description = "Show Hidden Categories", DefaultValue = false}
            )
        };
        schema.Query.AddField(getAllCategoriesFieldType);
    }

    private async Task<IPagedList<CatalogModule.Domain.Catalog.Category>> ResolveAsync(
        IResolveFieldContext resolveContext)
    {
        var categoryService = resolveContext?.RequestServices?.GetService<ICategoryService>();

        var parentId = resolveContext?.GetArgument<string>("parentId");
        var pageIndex = resolveContext?.GetArgument<int>("pageIndex");
        var pageSize = resolveContext?.GetArgument<int>("pageSize");
        var categoryName = resolveContext?.GetArgument<string>("categoryName");
        var showHidden = resolveContext?.GetArgument<bool>("showHidden");

        var categories = await categoryService?.GetAllCategories(
            parentId: parentId,
            pageIndex: pageIndex!.Value,
            pageSize: pageSize!.Value,
            categoryName: categoryName,
            showHidden: showHidden!.Value
        )!;
        return categories;
    }

}
