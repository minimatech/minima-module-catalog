using GraphQL.Types;

namespace Minima.CatalogModule.Api.GraphQL.Category.Types;

public sealed class CategoryType : ObjectGraphType<Domain.Domain.Catalog.Category>
{
    public CategoryType()
    {
        Name = "Category";

        Field(h => h.Id)
            .Description("Category Id");

        Field(h => h.Name)
            .Description("Category Name");

        Field(h => h.Description, nullable: true)
            .Description("Category Description");

        Field(x=> x.MetaDescription, nullable:true)
            .Description("Category Meta Description");

        Field(x=> x.MetaTitle, nullable:true)
            .Description("Category Meta Title");

        Field(x=> x.Published, nullable:true)
            .Description("Category Published");

        Field(x=> x.DisplayOrder, nullable:true)
            .Description("Category Display Order");

        Field(x=> x.CreatedOnUtc, nullable:true)
            .Description("Category Created On Utc");

        Field(x=> x.UpdatedOnUtc, nullable:true)
            .Description("Category Updated On Utc");

        Field(x=> x.ParentCategoryId, nullable:true)
            .Description("Category Parent Category Id");

        Field(x=> x.PictureId, nullable:true)
            .Description("Category Picture Id");

        Field(x=> x.ExternalId, nullable:true)
            .Description("Category External Id");



    }
}
