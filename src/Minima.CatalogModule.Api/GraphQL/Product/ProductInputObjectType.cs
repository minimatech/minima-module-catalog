using GraphQL;
using GraphQL.Types;
using Microsoft.Extensions.DependencyInjection;
using Minima.CatalogCore.Business.Services.Products;
using Minima.Platform.GraphQL.Abstractions.Queries;

namespace Minima.CatalogModule.Api.GraphQL.Product;

public class ProductInputObjectType : WhereInputObjectGraphType<Infrastructure.Domain.Catalog.Product>
{
    public ProductInputObjectType()
    {

        AddScalarFilterFields<IdGraphType>("listProductItemId", "asdas");


    }

    private async Task<Infrastructure.Domain.Catalog.Product> ResolveAsync(IResolveFieldContext resolveContext)
    {
        try
        {
            var productService = resolveContext?.RequestServices?.GetService<IProductService>();
            var product = resolveContext.GetArgument<Infrastructure.Domain.Catalog.Product>("product");
            await productService.InsertProduct(product);
            return product;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}
