using GraphQL.Types;

namespace Minima.CatalogModule.Api.GraphQL.Category.Types;

public sealed class CategoryInputType : InputObjectGraphType<Infrastructure.Domain.Catalog.Category>
{
    public CategoryInputType()
    {
        Name = "CategoryInput";
        Field(x => x.Name);
        Field(x => x.Description);
        Field(x => x.MetaDescription, nullable:true);
        Field(x => x.MetaTitle, nullable:true);
        Field(x => x.Published, nullable:true);
        Field(x => x.DisplayOrder, nullable:true);
        Field(x => x.CreatedOnUtc, nullable:true);
        Field(x => x.UpdatedOnUtc, nullable:true);
        Field(x=> x.ParentCategoryId, nullable:true);
        Field(x => x.PictureId, nullable:true);
        Field(x => x.ExternalId, nullable:true);

    }
}
