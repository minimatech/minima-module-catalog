using GraphQL.Types;

namespace Minima.CatalogModule.Api.GraphQL.Product;

public sealed class ProductType : ObjectGraphType<Domain.Domain.Catalog.Product>
{
    public ProductType()
    {
        Name = "ProductT";

        Field(h => h.Name).Description("The id of the human.");
        Field(h => h.ShortDescription, nullable: true).Description("The name of the human.");

    }
}
