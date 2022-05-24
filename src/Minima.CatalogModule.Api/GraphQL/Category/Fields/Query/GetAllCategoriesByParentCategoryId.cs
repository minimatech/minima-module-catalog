using System.Collections.Generic;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Types;
using Microsoft.Extensions.DependencyInjection;
using Minima.CatalogCore.Business.Services.Categories;
using Minima.CatalogModule.Api.GraphQL.Category.Types;
using Minima.GraphQL.Abstractions;
using Minima.GraphQL.Abstractions.Resolvers;

namespace Minima.CatalogModule.Api.GraphQL.Category.Fields.Query;

public class GetAllCategoriesByParentCategoryId : IQueryFieldMarker
{
    private readonly ISchemaFactory _schemaFactory;

    public GetAllCategoriesByParentCategoryId(ISchemaFactory schemaFactory)
    {
        _schemaFactory = schemaFactory;
    }

    public async Task BuildQueryFields()
    {
        var schema = await _schemaFactory.GetSchemaAsync();
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
}
