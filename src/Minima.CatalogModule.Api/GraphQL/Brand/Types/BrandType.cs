using GraphQL.Types;

namespace Minima.CatalogModule.Api.GraphQL.Brand.Types;

public sealed class BrandType : ObjectGraphType<Infrastructure.Domain.Catalog.Brand>
{
    public BrandType()
    {
        Name = "Brand";

        Field(h => h.Id)
            .Description("Brand Id");

        Field(h => h.Name)
            .Description("Brand Name");

        Field(h => h.Description, nullable: true)
            .Description("Brand Description");

        Field(x=> x.MetaDescription, nullable:true)
            .Description("Brand Meta Description");

        Field(x=> x.MetaTitle, nullable:true)
            .Description("Brand Meta Title");

        Field(x=> x.Published, nullable:true)
            .Description("Category Published");

        Field(x=> x.DisplayOrder, nullable:true)
            .Description("Brand Display Order");

        Field(x=> x.CreatedOnUtc, nullable:true)
            .Description("Brand Created On Utc");

        Field(x=> x.UpdatedOnUtc, nullable:true)
            .Description("Brand Updated On Utc");

        Field(x=> x.PictureId, nullable:true)
            .Description("Brand Picture Id");

        Field(x=> x.ExternalId, nullable:true)
            .Description("Brand External Id");



    }
}
