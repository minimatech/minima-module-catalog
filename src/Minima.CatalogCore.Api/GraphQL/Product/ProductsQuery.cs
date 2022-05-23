using GraphQL;
using GraphQL.Types;
using Microsoft.Extensions.DependencyInjection;
using Minima.CatalogCore.Business.Services.Products;
using Minima.Domain;
using Minima.GraphQL.Abstractions;
using Minima.GraphQL.Abstractions.Resolvers;

namespace Minima.CatalogModule.Api.GraphQL.Product;

public class ProductsQuery : ISchemaBuilder
{
    public Task<string> GetIdentifierAsync() => Task.FromResult(String.Empty);

    public Task BuildAsync(ISchema schema)
    {
        try
        {
            var field = new FieldType {
                Name = "Product",
                Description = "Site layers define the rules and zone placement for widgets.",
                Type = typeof(ListGraphType<ProductQueryObjectType>),
                Resolver =  new LockedAsyncFieldResolver<(IPagedList<CatalogModule.Domain.Catalog.Product> products, IList<string>)>(ResolveAsync)
            };
            schema.Query.AddField(field);
            
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }



        return Task.CompletedTask;
    }
    
    private  async Task<(IPagedList<CatalogModule.Domain.Catalog.Product> products, IList<string>)> ResolveAsync(IResolveFieldContext resolveContext)
    {
        try
        {
            var layerService = resolveContext?.RequestServices?.GetService<IProductService>();
            var allLayers = await  layerService.SearchProducts();
            return allLayers;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

    }
}