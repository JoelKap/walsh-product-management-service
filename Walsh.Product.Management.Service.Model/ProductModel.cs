namespace Walsh.Product.Management.Service.Model
{
    public class ProductModel
    {
        public int ProductId { get; set; }
        public int LocationId { get; set; }
        public int CategoryId { get; set; }
        public string ProductTitle { get; set; }
        public string ProductImageUrl { get; set; }
        public string ProductDescription { get; set; }
        public bool ProductLike { get; set; }
        public int ProductPrice { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public ICollection<ProductReviewModel> Reviews { get; set; }
        public ProductStockModel Stock { get; set; }
    }
}