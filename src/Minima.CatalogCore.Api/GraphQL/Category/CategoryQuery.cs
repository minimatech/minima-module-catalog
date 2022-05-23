#nullable enable
using GraphQL;
using GraphQL.Types;
using Microsoft.Extensions.DependencyInjection;
using Minima.CatalogCore.Business.Services.Categories;
using Minima.CatalogModule.Api.GraphQL.Category.Types;
using Minima.Domain;
using Minima.GraphQL.Abstractions;
using Minima.GraphQL.Abstractions.Resolvers;

namespace Minima.CatalogModule.Api.GraphQL.Category;

public class CategoryQuery : ISchemaBuilder, IGraphQLQueryMarker
{
    public Task<string> GetIdentifierAsync() => Task.FromResult(string.Empty);

    public Task BuildAsync(ISchema schema)
    {
        AddGetAllCategoriesField(schema);

        GetAllCategoriesByParentCategoryIdField(schema);

        return Task.CompletedTask;
    }

    private void GetAllCategoriesByParentCategoryIdField(ISchema schema)
    {
        var getAllCategoriesByParentCategoryId = new FieldType
        {
            Name = "getAllCategoriesByParentCategoryId",
            Type = typeof(ListGraphType<CategoryType>),
            Resolver = new LockedAsyncFieldResolver<IList<CatalogModule.Domain.Catalog.Category>>(
                GetAllCategoriesByParentCategoryIdResolveAsync),
            Arguments = new QueryArguments(
                new QueryArgument<StringGraphType>
                    {Name = "parentCategoryId", Description = "Parent CategoryId", DefaultValue = ""},
                new QueryArgument<BooleanGraphType>
                    {Name = "showHidden", Description = "Show Hidden Categories", DefaultValue = false},
                new QueryArgument<BooleanGraphType>
                    {Name = "includeAllLevels", Description = "Include All Levels", DefaultValue = false}
            )
        };
        schema.Query.AddField(getAllCategoriesByParentCategoryId);
    }

    private async Task<IList<Domain.Catalog.Category>> GetAllCategoriesByParentCategoryIdResolveAsync(IResolveFieldContext resolveContext)
    {
        var categoryService = resolveContext?.RequestServices?.GetService<ICategoryService>();
        
        var parentCategoryId = resolveContext?.GetArgument<string>("parentCategoryId");
        var showHidden = resolveContext?.GetArgument<bool>("showHidden");
        var includeAllLevels = resolveContext?.GetArgument<bool>("includeAllLevels");

        var categories = await categoryService?.GetAllCategoriesByParentCategoryId(
            parentCategoryId: parentCategoryId,
            showHidden: showHidden!.Value,
            includeAllLevels: includeAllLevels!.Value
        )!;
        return categories;
    }

    private void AddGetAllCategoriesField(ISchema schema)
    {
        var getAllCategoriesFieldType = new FieldType
        {
            Name = "getAllCategories",
            Type = typeof(ListGraphType<CategoryType>),
            Resolver = new LockedAsyncFieldResolver<IPagedList<CatalogModule.Domain.Catalog.Category>>(ResolveAsync),
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