using GraphQL;
using GraphQL.Types;
using Microsoft.Extensions.DependencyInjection;
using Minima.CatalogCore.Business.Services.Products;
using Minima.GraphQL.Abstractions.Queries;

namespace Minima.CatalogModule.Api.GraphQL.Product;

public class ProductInputObjectType : WhereInputObjectGraphType<Domain.Domain.Catalog.Product>
{
    public ProductInputObjectType()
    {

        AddScalarFilterFields<IdGraphType>("listProductItemId", "asdas");


    }

    private async Task<Domain.Domain.Catalog.Product> ResolveAsync(IResolveFieldContext resolveContext)
    {
        try
        {
            var productService = resolveContext?.RequestServices?.GetService<IProductService>();
            var product = resolveContext.GetArgument<Domain.Domain.Catalog.Product>("product");
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
