using GraphQL;
using GraphQL.Types;
using Microsoft.Extensions.DependencyInjection;
using Minima.CatalogCore.Business.Services.Categories;
using Minima.CatalogModule.Api.GraphQL.Category.Types;
using Minima.GraphQL.Abstractions;
using Minima.GraphQL.Abstractions.Resolvers;

namespace Minima.CatalogModule.Api.GraphQL.Category;

public class CategoryMutation : ISchemaBuilder
{
    public Task<string> GetIdentifierAsync()
    {
        return Task.FromResult(string.Empty);
    }

    public Task BuildAsync(ISchema schema)
    {
        var field = new FieldType {
            Name = "createCategory",
            Arguments = new QueryArguments(new QueryArgument<CategoryInputType> {Name = "category"}
            ),
            Description = "Site Category Mutations",
            Type = typeof(CategoryType),
            Resolver = new LockedAsyncFieldResolver<CatalogModule.Domain.Catalog.Category>(ResolveAsync)
        };
        schema.Mutation?.AddField(field);
        return Task.CompletedTask;
    }

    private async Task<CatalogModule.Domain.Catalog.Category> ResolveAsync(IResolveFieldContext resolveContext)
    {
        var categoryService = resolveContext?.RequestServices?.GetService<ICategoryService>();
        var category = resolveContext?.GetArgument<CatalogModule.Domain.Catalog.Category>("category");
        await categoryService!.InsertCategory(category);
        return category;
    }
}