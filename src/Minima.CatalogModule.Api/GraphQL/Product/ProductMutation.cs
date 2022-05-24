using GraphQL;
using GraphQL.Types;
using Microsoft.Extensions.DependencyInjection;
using Minima.CatalogCore.Business.Services.Products;
using Minima.GraphQL.Abstractions;
using Minima.GraphQL.Abstractions.Resolvers;

namespace Minima.CatalogModule.Api.GraphQL.Product;

public class ProductMutation : ISchemaBuilder
{

    public Task<string> GetIdentifierAsync() => Task.FromResult(String.Empty);
    public Task BuildAsync(ISchema schema)
    {
        try
        {
            var field = new FieldType {
                Name = "createProduct",
                Arguments = new QueryArguments(new QueryArgument<ProductInputType> {Name = "product"}
                ),
                //Description = "Site layers define the rules and zone placement for widgets.",
                Type = typeof(ProductType),
                Resolver =  new LockedAsyncFieldResolver<Domain.Domain.Catalog.Product>(ResolveAsync)
            };
            schema.Mutation?.AddField(field);

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        return Task.CompletedTask;
    }

    private async Task<Domain.Domain.Catalog.Product> ResolveAsync(IResolveFieldContext resolveContext)
    {
        var layerService = resolveContext?.RequestServices?.GetService<IProductService>();
        var product = resolveContext.GetArgument<Domain.Domain.Catalog.Product>("product");
        await  layerService.InsertProduct(product);
        return product;
    }
}
