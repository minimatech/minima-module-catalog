using Microsoft.AspNetCore.Mvc.Rendering;
using Minima.CatalogModule.Infrastructure.Domain.Catalog;
using Minima.Infrastructure.Models;

namespace Minima.CatalogCore.Business.Models.Catalog;

public class ProductModel : BaseEntityModel
{
    public ProductModel()
    {
        //Locales = new List<ProductLocalizedModel>();
        ProductPictureModels = new List<ProductPictureModel>();
        //CopyProductModel = new CopyProductModel();
        AvailableBasepriceUnits = new List<SelectListItem>();
        AvailableBasepriceBaseUnits = new List<SelectListItem>();
        //AvailableProductLayouts = new List<SelectListItem>();
        AvailableTaxCategories = new List<SelectListItem>();
        AvailableDeliveryDates = new List<SelectListItem>();
        //AvailableWarehouses = new List<SelectListItem>();
        AvailableProductAttributes = new List<SelectListItem>();
        AvailableUnits = new List<SelectListItem>();
        AddPictureModel = new ProductPictureModel();
        //ProductWarehouseInventoryModels = new List<ProductWarehouseInventoryModel>();
        //CalendarModel = new GenerateCalendarModel();
    }

    public override string Id { get; set; }
    public string PictureThumbnailUrl { get; set; }
    public int ProductTypeId { get; set; }
    public string ProductTypeName { get; set; }
    public bool AuctionEnded { get; set; }
    public string AssociatedToProductId { get; set; }
    public string AssociatedToProductName { get; set; }
    public bool VisibleIndividually { get; set; }
    public string ProductLayoutId { get; set; }
    public string Name { get; set; }
    public string ShortDescription { get; set; }
    public string FullDescription { get; set; }
    public string Flag { get; set; }
    public string AdminComment { get; set; }
    public string BrandId { get; set; }
    public string VendorId { get; set; }
    public bool BestSeller { get; set; }
    public string MetaKeywords { get; set; }
    public string MetaDescription { get; set; }
    public string MetaTitle { get; set; }
    public string SeName { get; set; }
    public string ProductTags { get; set; }
    public string Sku { get; set; }
    public string Mpn { get; set; }
    public virtual string Gtin { get; set; }
    public bool RequireOtherProducts { get; set; }
    public string RequiredProductIds { get; set; }
    public bool AutoAddRequiredProducts { get; set; }
    public bool IsShipEnabled { get; set; }

    public bool IsFreeShipping { get; set; }

    //public bool ShipSeparately { get; set; }
    public IList<SelectListItem> AvailableDeliveryDates { get; set; }
    public bool IsTaxExempt { get; set; }
    public string TaxCategoryId { get; set; }

    public IList<SelectListItem> AvailableTaxCategories { get; set; }
    public bool IsTele { get; set; }
    //public int ManageInventoryMethodId { get; set; }
    //public bool UseMultipleWarehouses { get; set; }
    //public string WarehouseId { get; set; }
    //public IList<SelectListItem> AvailableWarehouses { get; set; }
    public int StockQuantity { get; set; }
    public int ReservedQuantity { get; set; }
    public string StockQuantityStr { get; set; }
    public bool StockAvailability { get; set; }
    public bool DisplayStockQuantity { get; set; }
    public int MinStockQuantity { get; set; }
    public int LowStockActivityId { get; set; }
    public int NotifyAdminForQuantityBelow { get; set; }
    public int BackorderModeId { get; set; }
    public bool AllowOutOfStockSubscriptions { get; set; }
    //public int OrderMinimumQuantity { get; set; }
    //public int OrderMaximumQuantity { get; set; }
    //public string AllowedQuantities { get; set; }
    //public bool NotReturnable { get; set; }
    //public bool DisableBuyButton { get; set; }
    public double Price { get; set; }
    public double OldPrice { get; set; }
    public double CatalogPrice { get; set; }

    public double StartPrice { get; set; }
    public double ProductCost { get; set; }
    public bool EnteredPrice { get; set; }
    public double MinEnteredPrice { get; set; }
    public double MaxEnteredPrice { get; set; }
    public bool BasepriceEnabled { get; set; }
    public double BasepriceAmount { get; set; }
    public string BasepriceUnitId { get; set; }
    public IList<SelectListItem> AvailableBasepriceUnits { get; set; }
    public double BasepriceBaseAmount { get; set; }
    public string BasepriceBaseUnitId { get; set; }

    public IList<SelectListItem> AvailableBasepriceBaseUnits { get; set; }
    //public bool MarkAsNew { get; set; }
    public DateTime? MarkAsNewStartDateTime { get; set; }
    public DateTime? MarkAsNewEndDateTime { get; set; }
    public string UnitId { get; set; }

    public IList<SelectListItem> AvailableUnits { get; set; }
    public double Weight { get; set; }
    public double Length { get; set; }
    public double Width { get; set; }
    public double Height { get; set; }
    public DateTime? AvailableStartDateTime { get; set; }
    public DateTime? AvailableEndDateTime { get; set; }
    public int DisplayOrder { get; set; }
    public int DisplayOrderCategory { get; set; }
    public int DisplayOrderBrand { get; set; }
    public int DisplayOrderCollection { get; set; }
    public int OnSale { get; set; }
    public bool Published { get; set; }
    public DateTime? CreatedOn { get; set; }
    public DateTime? UpdatedOn { get; set; }
    public long Ticks { get; set; }

    public string PrimaryStoreCurrencyCode { get; set; }
    public string BaseDimensionIn { get; set; }
    public string BaseWeightIn { get; set; }

    //public IList<ProductLocalizedModel> Locales { get; set; }
    public string[] CustomerGroups { get; set; }

    //vendor
    public bool IsLoggedInAsVendor { get; set; }

    //product attributes
    public IList<SelectListItem> AvailableProductAttributes { get; set; }

    //pictures
    public ProductPictureModel AddPictureModel { get; set; }
    public IList<ProductPictureModel> ProductPictureModels { get; set; }


    //public IList<ProductWarehouseInventoryModel> ProductWarehouseInventoryModels { get; set; }

    //copy product
    //public CopyProductModel CopyProductModel { get; set; }

    #region Nested classes

    public class AddProductModel : BaseModel
    {
        public AddProductModel()
        {
            AvailableStores = new List<SelectListItem>();
            AvailableVendors = new List<SelectListItem>();
            AvailableProductTypes = new List<SelectListItem>();
        }

        public string SearchProductName { get; set; }
        public string SearchCategoryId { get; set; }
        public string SearchBrandId { get; set; }
        public string SearchCollectionId { get; set; }
        public string SearchVendorId { get; set; }
        public int SearchProductTypeId { get; set; }

        public IList<SelectListItem> AvailableStores { get; set; }
        public IList<SelectListItem> AvailableVendors { get; set; }
        public IList<SelectListItem> AvailableProductTypes { get; set; }

        //vendor
        public bool IsLoggedInAsVendor { get; set; }
    }


    public class AddRequiredProductModel : AddProductModel
    {
    }

    public class AddProductSpecificationAttributeModel : BaseModel
    {
        public AddProductSpecificationAttributeModel()
        {
            AvailableAttributes = new List<SelectListItem>();
            AvailableOptions = new List<SelectListItem>();
        }

        public string Id { get; set; }
        public string SpecificationAttributeId { get; set; }
        public SpecificationAttributeType AttributeTypeId { get; set; }
        public string SpecificationAttributeOptionId { get; set; }
        public string CustomName { get; set; }
        public string CustomValue { get; set; }
        public bool AllowFiltering { get; set; }
        public bool ShowOnProductPage { get; set; }
        public int DisplayOrder { get; set; }
        public string ProductId { get; set; }
        public IList<SelectListItem> AvailableAttributes { get; set; }
        public IList<SelectListItem> AvailableOptions { get; set; }
    }

    public class ProductPictureModel : BaseEntityModel
    {
        public string ProductId { get; set; }
        public string PictureId { get; set; }
        public string PictureUrl { get; set; }
        public int DisplayOrder { get; set; }
        public string AltAttribute { get; set; }
        public string TitleAttribute { get; set; }
        public string Style { get; set; }
        public string ExtraField { get; set; }


    }

    public class ProductCategoryModel : BaseEntityModel
    {
        public string Category { get; set; }
        public string ProductId { get; set; }
        public string CategoryId { get; set; }
        public int DisplayOrder { get; set; }
    }

    public class ProductCollectionModel : BaseEntityModel
    {
        public string Collection { get; set; }
        public string ProductId { get; set; }
        public string CollectionId { get; set; }
        public bool IsFeaturedProduct { get; set; }
        public int DisplayOrder { get; set; }
    }

    public class RelatedProductModel : BaseEntityModel
    {
        public string ProductId1 { get; set; }
        public string ProductId2 { get; set; }
        public string Product2Name { get; set; }
        public int DisplayOrder { get; set; }
    }

    public class AddRelatedProductModel : AddProductModel
    {
        public string ProductId { get; set; }
        public string[] SelectedProductIds { get; set; }
    }

    public class SimilarProductModel : BaseEntityModel
    {
        public string ProductId1 { get; set; }
        public string ProductId2 { get; set; }
        public string Product2Name { get; set; }
        public int DisplayOrder { get; set; }
    }

    public class AddSimilarProductModel : AddProductModel
    {
        public string ProductId { get; set; }

        public string[] SelectedProductIds { get; set; }
    }

    public class BundleProductModel : BaseEntityModel
    {
        public string ProductBundleId { get; set; }
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public int DisplayOrder { get; set; }
    }

    public class AddBundleProductModel : AddProductModel
    {
        public string ProductId { get; set; }

        public string[] SelectedProductIds { get; set; }
    }

    public class AssociatedProductModel : BaseEntityModel
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public int DisplayOrder { get; set; }
    }

    public class AddAssociatedProductModel : AddProductModel
    {
        public string ProductId { get; set; }

        public string[] SelectedProductIds { get; set; }
    }

    public class CrossSellProductModel : BaseEntityModel
    {
        public string ProductId { get; set; }
        public string Product2Name { get; set; }
    }

    public class AddCrossSellProductModel : AddProductModel
    {
        public string ProductId { get; set; }

        public string[] SelectedProductIds { get; set; }
    }

    public class RecommendedProductModel : BaseEntityModel
    {
        public string ProductId { get; set; }
        public string Product2Name { get; set; }
    }

    public class AddRecommendedProductModel : AddProductModel
    {
        public string ProductId { get; set; }

        public string[] SelectedProductIds { get; set; }
    }

    public class ProductPriceModel : BaseEntityModel
    {
        public string CurrencyCode { get; set; }

        public double Price { get; set; }
    }

    public class TierPriceModel : BaseEntityModel
    {
        public TierPriceModel()
        {
            AvailableStores = new List<SelectListItem>();
            AvailableCustomerGroups = new List<SelectListItem>();
            AvailableCurrencies = new List<SelectListItem>();
        }

        public string ProductId { get; set; }
        public string CustomerGroupId { get; set; }

        public IList<SelectListItem> AvailableCustomerGroups { get; set; }
        public string CustomerGroup { get; set; }
        public string StoreId { get; set; }

        public IList<SelectListItem> AvailableStores { get; set; }
        public string Store { get; set; }
        public string CurrencyCode { get; set; }

        public IList<SelectListItem> AvailableCurrencies { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public DateTime? StartDateTime { get; set; }
        public DateTime? EndDateTime { get; set; }
    }

    public class ProductWarehouseInventoryModel : BaseModel
    {
        public string WarehouseId { get; set; }
        public string WarehouseName { get; set; }
        public bool WarehouseUsed { get; set; }
        public int StockQuantity { get; set; }
        public int ReservedQuantity { get; set; }
    }

    public class ReservationModel : BaseEntityModel
    {
        public string ReservationId { get; set; }
        public DateTime Date { get; set; }
        public string Resource { get; set; }
        public string Parameter { get; set; }
        public string OrderId { get; set; }
        public string ProductId { get; set; }
        public string Duration { get; set; }
    }

    public class BidModel : BaseEntityModel
    {
        public string ProductId { get; set; }
        public string BidId { get; set; }
        public DateTime Date { get; set; }
        public string CustomerId { get; set; }
        public string Email { get; set; }
        public string Amount { get; set; }
        public string OrderId { get; set; }
    }


    public class ProductAttributeMappingModel : BaseEntityModel
    {
        public ProductAttributeMappingModel()
        {
            AvailableProductAttribute = new List<SelectListItem>();
        }

        public string ProductId { get; set; }

        public string ProductAttributeId { get; set; }
        public string ProductAttribute { get; set; }

        public IList<SelectListItem> AvailableProductAttribute { get; set; }
        public string TextPrompt { get; set; }
        public bool IsRequired { get; set; }
        public bool ShowOnCatalogPage { get; set; }

        public AttributeControlType AttributeControlTypeId { get; set; }
        public string AttributeControlType { get; set; }
        public int DisplayOrder { get; set; }
        public bool Combination { get; set; }

        public bool ShouldHaveValues { get; set; }
        public int TotalValues { get; set; }

        //validation fields
        public bool ValidationRulesAllowed { get; set; }
        public int? ValidationMinLength { get; set; }
        public int? ValidationMaxLength { get; set; }
        public string ValidationFileAllowedExtensions { get; set; }
        public int? ValidationFileMaximumSize { get; set; }
        public string DefaultValue { get; set; }
        public string ValidationRulesString { get; set; }

        //condition
        public bool ConditionAllowed { get; set; }
        public string ConditionString { get; set; }
    }

    public class ProductAttributeValueListModel : BaseModel
    {
        public string ProductId { get; set; }

        public string ProductName { get; set; }

        public string ProductAttributeMappingId { get; set; }

        public string ProductAttributeName { get; set; }
    }

    public class ProductAttributeValueModel : BaseEntityModel
    {
        public ProductAttributeValueModel()
        {
            ProductPictureModels = new List<ProductPictureModel>();
            Locales = new List<ProductAttributeValueLocalizedModel>();
        }

        public string ProductAttributeMappingId { get; set; }
        public string ProductId { get; set; }


        public AttributeValueType AttributeValueTypeId { get; set; }
        public string AttributeValueTypeName { get; set; }
        public string AssociatedProductId { get; set; }
        public string AssociatedProductName { get; set; }
        public string Name { get; set; }

        public string ColorSquaresRgb { get; set; }

        public bool DisplayColorSquaresRgb { get; set; }

        public string ImageSquaresPictureId { get; set; }

        public bool DisplayImageSquaresPicture { get; set; }
        public double PriceAdjustment { get; set; }
        //used only on the values list page
        public string PriceAdjustmentStr { get; set; }

        public string PrimaryStoreCurrencyCode { get; set; }
        public double WeightAdjustment { get; set; }
        //used only on the values list page
        public string WeightAdjustmentStr { get; set; }
        public double Cost { get; set; }
        public int Quantity { get; set; }
        public bool IsPreSelected { get; set; }
        public int DisplayOrder { get; set; }
        public string PictureId { get; set; }
        public string PictureThumbnailUrl { get; set; }

        public IList<ProductPictureModel> ProductPictureModels { get; set; }
        public IList<ProductAttributeValueLocalizedModel> Locales { get; set; }

        #region Nested classes

        public class AssociateProductToAttributeValueModel : AddProductModel
        {
            public string AssociatedToProductId { get; set; }
        }

        #endregion
    }

    public class ActivityLogModel : BaseEntityModel
    {
        public string ActivityLogTypeName { get; set; }

        public string Comment { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CustomerId { get; set; }

        public string CustomerEmail { get; set; }
    }

    public class ProductAttributeValueLocalizedModel
    {
        public string LanguageId { get; set; }

        public string Name { get; set; }
    }

    public class ProductAttributeCombinationModel : BaseEntityModel
    {
        public string ProductId { get; set; }
        public string Attributes { get; set; }
        public string Warnings { get; set; }
        public int StockQuantity { get; set; }
        public bool AllowOutOfStockOrders { get; set; }
        public string Sku { get; set; }
        public string Mpn { get; set; }
        public string Gtin { get; set; }
        public double? OverriddenPrice { get; set; }
        public int NotifyAdminForQuantityBelow { get; set; }
    }

    public class ProductAttributeCombinationTierPricesModel : BaseEntityModel
    {
        public string StoreId { get; set; }
        public string Store { get; set; }

        /// <summary>
        /// Gets or sets the customer group identifier
        /// </summary>
        public string CustomerGroupId { get; set; }

        public string CustomerGroup { get; set; }

        /// <summary>
        /// Gets or sets the quantity
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Gets or sets the price
        /// </summary>
        public double Price { get; set; }
    }

    #endregion
}

