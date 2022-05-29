using GraphQL.Types;
using Microsoft.Extensions.DependencyInjection;
using Minima.GraphQL.Abstractions;

namespace Minima.CatalogModule.Api.GraphQL.Category;

public class CategoryQuery : ISchemaBuilder, IGraphQLQueryMarker
{
    private IServiceProvider _serviceProvider;

    public CategoryQuery(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public Task<string> GetIdentifierAsync() => Task.FromResult(string.Empty);

    public async Task BuildAsync(ISchema schema)
    {
        var queryFieldMarkers = _serviceProvider.GetServices<IQueryFieldMarker>();
        foreach (var queryFieldMarker in queryFieldMarkers)
        {
            await queryFieldMarker.BuildQueryFields();
        }

        //return Task.CompletedTask;
    }


}
