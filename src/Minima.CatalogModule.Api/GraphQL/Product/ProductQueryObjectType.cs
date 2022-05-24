using GraphQL.Types;

namespace Minima.CatalogModule.Api.GraphQL.Product;

public sealed class ProductQueryObjectType : ObjectGraphType<Domain.Domain.Catalog.Product>
{
    public ProductQueryObjectType()
    {
        Name = "ProductQuery";

        Field(layer => layer.Id, type:typeof(IdGraphType)).Description("The name of the layer.");
        Field(layer => layer.Name).Description("Deprecated. The rule that activates the layer.");
        Field(layer => layer.FullDescription).Description("Deprecated. The rule that activates the layer.");


        // Field<ListGraphType<StringGraphType>, IEnumerable<Condition>>()
        //     .Name("layerrule")
        //     .Description("The rule that activates the layer.")
        //     .Resolve(ctx => ctx.Source.LayerRule.Conditions);

        Field(layer => layer.ShortDescription).Description("The description of the layer.");

        // Field<ListGraphType<LayerWidgetQueryObjectType>, IEnumerable<ContentItem>>()
        //     .Name("widgets")
        //     .Description("The widgets for this layer.")
        //     .Argument<PublicationStatusGraphType, PublicationStatusEnum>("status", "publication status of the widgets")
        //     .ResolveLockedAsync(async ctx =>
        //     {
        //         var context = (GraphQLContext)ctx.UserContext;
        //         var layerService = context.ServiceProvider.GetService<ILayerService>();
        //
        //         var filter = GetVersionFilter(ctx.GetArgument<PublicationStatusEnum>("status"));
        //         var widgets = await layerService.GetLayerWidgetsAsync(filter);
        //
        //         var layerWidgets = widgets?.Where(item =>
        //         {
        //             var metadata = item.As<LayerMetadata>();
        //             if (metadata == null) return false;
        //             return metadata.Layer == ctx.Source.Name;
        //         });
        //
        //         return layerWidgets;
        //     });
    }

    // private Expression<Func<ContentItemIndex, bool>> GetVersionFilter(PublicationStatusEnum status)
    // {
    //     switch (status)
    //     {
    //         case PublicationStatusEnum.Published: return x => x.Published;
    //         case PublicationStatusEnum.Draft: return x => x.Latest && !x.Published;
    //         case PublicationStatusEnum.Latest: return x => x.Latest;
    //         case PublicationStatusEnum.All: return x => true;
    //         default: return x => x.Published;
    //     }
    // }
}
