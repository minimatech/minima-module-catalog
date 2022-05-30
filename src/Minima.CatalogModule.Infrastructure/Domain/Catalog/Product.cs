using Minima.Infrastructure.Domain;
using Minima.Infrastructure.Domain.Localization;
using Minima.Infrastructure.Domain.Permissions;

namespace Minima.CatalogModule.Infrastructure.Domain.Catalog;

/// <summary>
/// Represents a product
/// </summary>
public partial class Product : BaseEntity, ITranslationEntity, IGroupLinkEntity
{
    private ICollection<ProductCategory> _productCategories;
    private ICollection<ProductCollection> _productCollections;
    private ICollection<ProductPicture> _productPictures;
    private ICollection<ProductSpecificationAttribute> _productSpecificationAttributes;
    private ICollection<ProductAttributeMapping> _productAttributeMappings;
    private ICollection<ProductAttributeCombination> _productAttributeCombinations;
    private ICollection<TierPrice> _tierPrices;
    private ICollection<string> _appliedDiscounts;
    private ICollection<ProductWarehouseInventory> _productWarehouseInventory;
    private ICollection<string> _crossSellProduct;
    private ICollection<string> _recommendedProduct;
    private ICollection<RelatedProduct> _relatedProduct;
    private ICollection<SimilarProduct> _similarProduct;
    private ICollection<BundleProduct> _bundleProduct;
    private ICollection<ProductPrice> _productprices;
    private ICollection<string> _productTags;
    public Product()
    {
        CustomerGroups = new List<string>();
        Locales = new List<TranslationEntity>();
        Stores = new List<string>();
    }

    /// <summary>
    /// Gets or sets the product type identifier
    /// </summary>
    public ProductType ProductTypeId { get; set; }
    /// <summary>
    /// Gets or sets the parent product identifier. It's used to identify associated products (only with "grouped" products)
    /// </summary>
    public string ParentGroupedProductId { get; set; }
    /// <summary>
    /// Gets or sets the values indicating whether this product is visible in catalog or search results.
    /// It's used when this product is associated to some "grouped" one
    /// This way associated products could be accessed/added/etc only from a grouped product details page
    /// </summary>
    public bool VisibleIndividually { get; set; }

    /// <summary>
    /// Gets or sets the name
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the sename
    /// </summary>
    public string SeName { get; set; }
    /// <summary>
    /// Gets or sets the short description
    /// </summary>
    public string ShortDescription { get; set; }
    /// <summary>
    /// Gets or sets the full description
    /// </summary>
    public string FullDescription { get; set; }

    /// <summary>
    /// Gets or sets the admin comment
    /// </summary>
    public string AdminComment { get; set; }

    /// <summary>
    /// Gets or sets a value of used product layout identifier
    /// </summary>
    public string ProductLayoutId { get; set; }

    /// <summary>
    /// Gets or sets a brand identifier
    /// </summary>
    public string BrandId { get; set; }

    /// <summary>
    /// Gets or sets a vendor identifier
    /// </summary>
    public string VendorId { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether to show the product on home page
    /// </summary>
    public bool ShowOnHomePage { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether to show the product on the bestseller section
    /// </summary>
    public bool BestSeller { get; set; }

    /// <summary>
    /// Gets or sets the meta keywords
    /// </summary>
    public string MetaKeywords { get; set; }
    /// <summary>
    /// Gets or sets the meta description
    /// </summary>
    public string MetaDescription { get; set; }
    /// <summary>
    /// Gets or sets the meta title
    /// </summary>
    public string MetaTitle { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the product allows customer reviews
    /// </summary>
    public bool AllowCustomerReviews { get; set; }
    /// <summary>
    /// Gets or sets the rating sum (approved reviews)
    /// </summary>
    public int ApprovedRatingSum { get; set; }
    /// <summary>
    /// Gets or sets the rating sum (not approved reviews)
    /// </summary>
    public int NotApprovedRatingSum { get; set; }
    /// <summary>
    /// Gets or sets the total rating votes (approved reviews)
    /// </summary>
    public int ApprovedTotalReviews { get; set; }
    /// <summary>
    /// Gets or sets the total rating votes (not approved reviews)
    /// </summary>
    public int NotApprovedTotalReviews { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the entity is subject to ACL
    /// </summary>
    public bool LimitedToGroups { get; set; }
    public IList<string> CustomerGroups { get; set; }
    /// <summary>
    /// Gets or sets a value indicating whether the entity is limited/restricted to certain stores
    /// </summary>
    public bool LimitedToStores { get; set; }
    public IList<string> Stores { get; set; }
    /// <summary>
    /// Gets or sets the ExternalId
    /// </summary>
    public string ExternalId { get; set; }
    /// <summary>
    /// Gets or sets the SKU
    /// </summary>
    public string Sku { get; set; }
    /// <summary>
    /// Gets or sets the collection part number
    /// </summary>
    public string Mpn { get; set; }
    /// <summary>
    /// Gets or sets the Global Trade Item Number (GTIN). These identifiers include UPC (in North America), EAN (in Europe), JAN (in Japan), and ISBN (for books).
    /// </summary>
    public string Gtin { get; set; }
    /// <summary>
    /// Gets or sets a value indicating whether the product is gift voucher
    /// </summary>
    public bool IsGiftVoucher { get; set; }
    /// <summary>
    /// Gets or sets the gift voucher type identifier
    /// </summary>
    public GiftVoucherType GiftVoucherTypeId { get; set; }
    /// <summary>
    /// Gets or sets gift voucher amount that can be used after purchase. If not specified, then product price will be used.
    /// </summary>
    public double? OverGiftAmount { get; set; }
    /// <summary>
    /// Gets or sets a value indicating whether the product requires that other products are added to the cart (Product X requires Product Y)
    /// </summary>
    public bool RequireOtherProducts { get; set; }
    /// <summary>
    /// Gets or sets a required product identifiers (comma separated)
    /// </summary>
    public string RequiredProductIds { get; set; }
    /// <summary>
    /// Gets or sets a value indicating whether required products are automatically added to the cart
    /// </summary>
    public bool AutoAddRequiredProducts { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the product is download
    /// </summary>
    public bool IsDownload { get; set; }
    /// <summary>
    /// Gets or sets the download identifier
    /// </summary>
    public string DownloadId { get; set; }
    /// <summary>
    /// Gets or sets a value indicating whether this downloadable product can be downloaded unlimited number of times
    /// </summary>
    public bool UnlimitedDownloads { get; set; }
    /// <summary>
    /// Gets or sets the maximum number of downloads
    /// </summary>
    public int MaxNumberOfDownloads { get; set; }
    /// <summary>
    /// Gets or sets the number of days during customers keeps access to the file.
    /// </summary>
    public int? DownloadExpirationDays { get; set; }
    /// <summary>
    /// Gets or sets the download activation type
    /// </summary>
    public DownloadActivationType DownloadActivationTypeId { get; set; }
    /// <summary>
    /// Gets or sets a value indicating whether the product has a sample download file
    /// </summary>
    public bool HasSampleDownload { get; set; }
    /// <summary>
    /// Gets or sets the sample download identifier
    /// </summary>
    public string SampleDownloadId { get; set; }
    /// <summary>
    /// Gets or sets a value indicating whether the product has user agreement
    /// </summary>
    public bool HasUserAgreement { get; set; }
    /// <summary>
    /// Gets or sets the text of license agreement
    /// </summary>
    public string UserAgreementText { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the product is recurring
    /// </summary>
    public bool IsRecurring { get; set; }
    /// <summary>
    /// Gets or sets the cycle length
    /// </summary>
    public int RecurringCycleLength { get; set; }
    /// <summary>
    /// Gets or sets the cycle period
    /// </summary>
    public RecurringCyclePeriod RecurringCyclePeriodId { get; set; }
    /// <summary>
    /// Gets or sets the total cycles
    /// </summary>
    public int RecurringTotalCycles { get; set; }
    /// <summary>
    /// Gets or sets include both dates
    /// </summary>
    public bool IncBothDate { get; set; }
    /// <summary>
    /// Gets or sets Interval
    /// </summary>
    public int Interval { get; set; }
    /// <summary>
    /// Gets or sets IntervalUnitId
    /// </summary>
    public IntervalUnit IntervalUnitId { get; set; }
    /// <summary>
    /// Gets or sets a value indicating whether the entity is ship enabled
    /// </summary>
    public bool IsShipEnabled { get; set; }
    /// <summary>
    /// Gets or sets a value indicating whether the entity is free shipping
    /// </summary>
    public bool IsFreeShipping { get; set; }
    /// <summary>
    /// Gets or sets a value this product should be shipped separately (each item)
    /// </summary>
    public bool ShipSeparately { get; set; }
    /// <summary>
    /// Gets or sets the additional shipping charge
    /// </summary>
    public double AdditionalShippingCharge { get; set; }
    /// <summary>
    /// Gets or sets a delivery date identifier
    /// </summary>
    public string DeliveryDateId { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the product is marked as tax exempt
    /// </summary>
    public bool IsTaxExempt { get; set; }
    /// <summary>
    /// Gets or sets the tax category identifier
    /// </summary>
    public string TaxCategoryId { get; set; }
    /// <summary>
    /// Gets or sets a value indicating whether the product is telecommunications or broadcasting or electronic services
    /// </summary>
    public bool IsTele { get; set; }

    /// <summary>
    /// Gets or sets a value indicating how to manage inventory
    /// </summary>
    public ManageInventoryMethod ManageInventoryMethodId { get; set; }
    /// <summary>
    /// Gets or sets a value indicating whether multiple warehouses are used for this product
    /// </summary>
    public bool UseMultipleWarehouses { get; set; }
    /// <summary>
    /// Gets or sets a warehouse identifier
    /// </summary>
    public string WarehouseId { get; set; }
    /// <summary>
    /// Gets or sets the stock quantity
    /// </summary>
    public int StockQuantity { get; set; }
    /// <summary>
    /// Gets or sets the reserved quantity (ordered but not shipped yet)
    /// </summary>
    public int ReservedQuantity { get; set; }
    /// <summary>
    /// Gets or sets a value indicating whether to display stock availability
    /// </summary>
    public bool StockAvailability { get; set; }
    /// <summary>
    /// Gets or sets a value indicating whether to display stock quantity
    /// </summary>
    public bool DisplayStockQuantity { get; set; }
    /// <summary>
    /// Gets or sets the minimum stock quantity
    /// </summary>
    public int MinStockQuantity { get; set; }
    /// <summary>
    /// Gets or sets the low stock
    /// </summary>
    public bool LowStock { get; set; }

    /// <summary>
    /// Gets or sets the low stock activity identifier
    /// </summary>
    public LowStockActivity LowStockActivityId { get; set; }
    /// <summary>
    /// Gets or sets the quantity when admin should be notified
    /// </summary>
    public int NotifyAdminForQuantityBelow { get; set; }
    /// <summary>
    /// Gets or sets a value backorder mode identifier
    /// </summary>
    public BackorderMode BackorderModeId { get; set; }
    /// <summary>
    /// Gets or sets a value indicating whether to out of stock subscriptions are allowed
    /// </summary>
    public bool AllowOutOfStockSubscriptions { get; set; }
    /// <summary>
    /// Gets or sets the order minimum quantity
    /// </summary>
    public int OrderMinimumQuantity { get; set; }
    /// <summary>
    /// Gets or sets the order maximum quantity
    /// </summary>
    public int OrderMaximumQuantity { get; set; }
    /// <summary>
    /// Gets or sets the comma seperated list of allowed quantities. null or empty if any quantity is allowed
    /// </summary>
    public string AllowedQuantities { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether this product is returnable (a customer is allowed to submit merchandise return with this product)
    /// </summary>
    public bool NotReturnable { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether to disable buy (Add to cart) button
    /// </summary>
    public bool DisableBuyButton { get; set; }
    /// <summary>
    /// Gets or sets a value indicating whether to disable "Add to wishlist" button
    /// </summary>
    public bool DisableWishlistButton { get; set; }
    /// <summary>
    /// Gets or sets a value indicating whether this item is available for Pre-Order
    /// </summary>
    public bool AvailableForPreOrder { get; set; }
    /// <summary>
    /// Gets or sets the start date and time of the product availability (for pre-order products)
    /// </summary>
    public DateTime? PreOrderDateTimeUtc { get; set; }
    /// <summary>
    /// Gets or sets a value indicating whether to show "Call for Pricing" or "Call for quote" instead of price
    /// </summary>
    public bool CallForPrice { get; set; }
    /// <summary>
    /// Gets or sets the price
    /// </summary>
    public double Price { get; set; }
    /// <summary>
    /// Gets or sets the old price
    /// </summary>
    public double OldPrice { get; set; }

    /// <summary>
    /// Gets or sets the catalog price
    /// </summary>
    public double CatalogPrice { get; set; }

    /// <summary>
    /// Gets or sets the product cost
    /// </summary>
    public double ProductCost { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether a customer enters price
    /// </summary>
    public bool EnteredPrice { get; set; }
    /// <summary>
    /// Gets or sets the minimum price entered by a customer
    /// </summary>
    public double MinEnteredPrice { get; set; }
    /// <summary>
    /// Gets or sets the maximum price entered by a customer
    /// </summary>
    public double MaxEnteredPrice { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether base price (PAngV) is enabled. Used by German users.
    /// </summary>
    public bool BasepriceEnabled { get; set; }
    /// <summary>
    /// Gets or sets an amount in product for PAngV
    /// </summary>
    public double BasepriceAmount { get; set; }
    /// <summary>
    /// Gets or sets a unit of product for PAngV (MeasureWeight entity)
    /// </summary>
    public string BasepriceUnitId { get; set; }
    /// <summary>
    /// Gets or sets a reference amount for PAngV
    /// </summary>
    public double BasepriceBaseAmount { get; set; }
    /// <summary>
    /// Gets or sets a reference unit for PAngV (MeasureWeight entity)
    /// </summary>
    public string BasepriceBaseUnitId { get; set; }

    /// <summary>
    /// Gets or sets a unit of product
    /// </summary>
    public string UnitId { get; set; }

    /// <summary>
    /// Gets or sets a course ident
    /// </summary>
    public string CourseId { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether this product is marked as new
    /// </summary>
    public bool MarkAsNew { get; set; }
    /// <summary>
    /// Gets or sets the start date and time of the new product (set product as "New" from date). Leave empty to ignore this property
    /// </summary>
    public DateTime? MarkAsNewStartDateTimeUtc { get; set; }
    /// <summary>
    /// Gets or sets the end date and time of the new product (set product as "New" to date). Leave empty to ignore this property
    /// </summary>
    public DateTime? MarkAsNewEndDateTimeUtc { get; set; }

    /// <summary>
    /// Gets or sets the weight
    /// </summary>
    public double Weight { get; set; }
    /// <summary>
    /// Gets or sets the length
    /// </summary>
    public double Length { get; set; }
    /// <summary>
    /// Gets or sets the width
    /// </summary>
    public double Width { get; set; }
    /// <summary>
    /// Gets or sets the height
    /// </summary>
    public double Height { get; set; }

    /// <summary>
    /// Gets or sets the available start date and time
    /// </summary>
    public DateTime? AvailableStartDateTimeUtc { get; set; }
    /// <summary>
    /// Gets or sets the available end date and time
    /// </summary>
    public DateTime? AvailableEndDateTimeUtc { get; set; }

    /// <summary>
    /// Gets or sets auction start price
    /// </summary>
    public double StartPrice { get; set; }

    /// <summary>
    /// Gets or sets current highest bid
    /// </summary>
    public double HighestBid { get; set; }

    /// <summary>
    /// Gets or sets current highest bidder customer id
    /// </summary>
    public string HighestBidder { get; set; }

    /// <summary>
    /// Gets or sets auction ended
    /// </summary>
    public bool AuctionEnded { get; set; }

    /// <summary>
    /// Gets or sets a display order.
    /// This value is used when sorting associated products (used with "grouped" products)
    /// This value is used when sorting home page products
    /// </summary>
    public int DisplayOrder { get; set; }

    /// <summary>
    /// Gets or sets a display order for category page.
    /// This value is used when sorting products on category page
    /// </summary>
    public int DisplayOrderCategory { get; set; }

    /// <summary>
    /// Gets or sets a display order for brand page.
    /// This value is used when sorting products on brand page
    /// </summary>
    public int DisplayOrderBrand { get; set; }

    /// <summary>
    /// Gets or sets a display order for collection page.
    /// This value is used when sorting products on collection page
    /// </summary>
    public int DisplayOrderCollection { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the entity is published
    /// </summary>
    public bool Published { get; set; }

    /// <summary>
    /// Gets or sets the date and time of product creation
    /// </summary>
    public DateTime CreatedOnUtc { get; set; }
    /// <summary>
    /// Gets or sets the date and time of product update
    /// </summary>
    public DateTime UpdatedOnUtc { get; set; }

    /// <summary>
    /// Gets or sets the sold
    /// </summary>
    public int Sold { get; set; }

    /// <summary>
    /// Gets or sets the viewed
    /// </summary>
    public Int64 Viewed { get; set; }

    /// <summary>
    /// Gets or sets the onsale
    /// </summary>
    public int OnSale { get; set; }

    /// <summary>
    /// Gets or sets the flag
    /// </summary>
    public string Flag { get; set; }

    // /// <summary>
    // /// Gets or sets the coordinates
    // /// </summary>
    // public GeoCoordinates Coordinates { get; set; }

    /// <summary>
    /// Gets or sets the collection of locales
    /// </summary>
    public IList<TranslationEntity> Locales { get; set; }

    /// <summary>
    /// Gets or sets the collection of ProductCategory
    /// </summary>
    public virtual ICollection<ProductCategory> ProductCategories
    {
        get { return _productCategories ??= new List<ProductCategory>(); }
        protected set { _productCategories = value; }
    }

    /// <summary>
    /// Gets or sets the collection of ProductCollection
    /// </summary>
    public virtual ICollection<ProductCollection> ProductCollections
    {
        get { return _productCollections ??= new List<ProductCollection>(); }
        protected set { _productCollections = value; }
    }

    /// <summary>
    /// Gets or sets the collection of ProductPicture
    /// </summary>
    public virtual ICollection<ProductPicture> ProductPictures
    {
        get { return _productPictures ??= new List<ProductPicture>(); }
        protected set { _productPictures = value; }
    }

    /// <summary>
    /// Gets or sets the product specification attribute
    /// </summary>
    public virtual ICollection<ProductSpecificationAttribute> ProductSpecificationAttributes
    {
        get { return _productSpecificationAttributes ??= new List<ProductSpecificationAttribute>(); }
        protected set { _productSpecificationAttributes = value; }
    }

    /// <summary>
    /// Gets or sets the product tags
    /// </summary>
    public virtual ICollection<string> ProductTags
    {
        get { return _productTags ??= new List<string>(); }
        protected set { _productTags = value; }
    }

    /// <summary>
    /// Gets or sets the product attribute mappings
    /// </summary>
    public virtual ICollection<ProductAttributeMapping> ProductAttributeMappings
    {
        get { return _productAttributeMappings ??= new List<ProductAttributeMapping>(); }
        protected set { _productAttributeMappings = value; }
    }

    /// <summary>
    /// Gets or sets the product attribute combinations
    /// </summary>
    public virtual ICollection<ProductAttributeCombination> ProductAttributeCombinations
    {
        get { return _productAttributeCombinations ??= new List<ProductAttributeCombination>(); }
        protected set { _productAttributeCombinations = value; }
    }
    /// <summary>
    /// Gets or sets the product prices
    /// </summary>
    public virtual ICollection<ProductPrice> ProductPrices {
        get { return _productprices ??= new List<ProductPrice>(); }
        protected set { _productprices = value; }
    }
    /// <summary>
    /// Gets or sets the tier prices
    /// </summary>
    public virtual ICollection<TierPrice> TierPrices
    {
        get { return _tierPrices ??= new List<TierPrice>(); }
        protected set { _tierPrices = value; }
    }

    /// <summary>
    /// Gets or sets the collection of applied discounts
    /// </summary>
    public virtual ICollection<string> AppliedDiscounts
    {
        get { return _appliedDiscounts ??= new List<string>(); }
        protected set { _appliedDiscounts = value; }
    }

    /// <summary>
    /// Gets or sets the collection of "ProductWarehouseInventory". We use it only when "UseMultipleWarehouses" is set to "true" and ManageInventoryMethod" to "ManageStock"
    /// </summary>
    public virtual ICollection<ProductWarehouseInventory> ProductWarehouseInventory
    {
        get { return _productWarehouseInventory ??= new List<ProductWarehouseInventory>(); }
        protected set { _productWarehouseInventory = value; }
    }

    public virtual ICollection<string> CrossSellProduct
    {
        get { return _crossSellProduct ??= new List<string>(); }
        protected set { _crossSellProduct = value; }
    }

    public virtual ICollection<string> RecommendedProduct
    {
        get { return _recommendedProduct ??= new List<string>(); }
        protected set { _recommendedProduct = value; }
    }

    public virtual ICollection<RelatedProduct> RelatedProducts
    {
        get { return _relatedProduct ??= new List<RelatedProduct>(); }
        protected set { _relatedProduct = value; }
    }
    public virtual ICollection<SimilarProduct> SimilarProducts {
        get { return _similarProduct ??= new List<SimilarProduct>(); }
        protected set { _similarProduct = value; }
    }
    public virtual ICollection<BundleProduct> BundleProducts
    {
        get { return _bundleProduct ??= new List<BundleProduct>(); }
        protected set { _bundleProduct = value; }
    }

}
