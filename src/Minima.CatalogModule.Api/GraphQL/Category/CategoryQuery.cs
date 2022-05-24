using GraphQL;
using GraphQL.Introspection;
using GraphQL.Types;
using Microsoft.Extensions.DependencyInjection;
using Minima.CatalogCore.Business.Services.Categories;
using Minima.CatalogModule.Api.GraphQL.Category.Types;
using Minima.GraphQL.Abstractions;
using Minima.GraphQL.Abstractions.Resolvers;
using Minima.Infrastructure;

namespace Minima.CatalogModule.Api.GraphQL.Category;

public class CategoryQuery : ISchemaBuilder, IGraphQLQueryMarker
{
    public Task<string> GetIdentifierAsync() => Task.FromResult(string.Empty);

    public Task BuildAsync(ISchema schema)
    {

        return Task.CompletedTask;
    }


}
