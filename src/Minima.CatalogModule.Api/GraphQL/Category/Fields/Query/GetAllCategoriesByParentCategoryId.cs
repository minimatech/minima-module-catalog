using GraphQL;
using GraphQL.Types;
using Microsoft.Extensions.DependencyInjection;
using Minima.CatalogCore.Business.Services.Categories;
using Minima.CatalogModule.Api.GraphQL.Category.Types;
using Minima.Platform.GraphQL.Abstractions;
using Minima.Platform.GraphQL.Abstractions.Resolvers;

namespace Minima.CatalogModule.Api.GraphQL.Category.Fields.Query;

public class GetAllCategoriesByParentCategoryId : IQueryFieldMarker
{
    public async Task BuildQueryFields(ISchema schema)
    {
        var getAllCategoriesByParentCategoryId = new FieldType
        {
            Name = "getAllCategoriesByParentCategoryId",
            Type = typeof(ListGraphType<CategoryType>),
            Resolver = new LockedAsyncFieldResolver<IList<Infrastructure.Domain.Catalog.Category>>(
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

    private async Task<IList<Infrastructure.Domain.Catalog.Category>> GetAllCategoriesByParentCategoryIdResolveAsync(IResolveFieldContext resolveContext)
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
}
