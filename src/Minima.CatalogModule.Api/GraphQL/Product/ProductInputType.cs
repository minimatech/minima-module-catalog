using GraphQL.Types;

namespace Minima.CatalogModule.Api.GraphQL.Product;

public class ProductInputType : InputObjectGraphType<CatalogModule.Domain.Catalog.Product>
{
    public ProductInputType()
    {
        Name = "ProductInput";
        Field(x => x.Name);
        Field(x => x.ShortDescription, nullable: true);
    }
}