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
        public string ProductReview { get; set; }
        public int ProductRating { get; set; }
        public int ProductPrice { get; set; } 
        public string ProductInStock { get; set; }
        public bool IsDeleted { get; set; } 
        public DateTime CreatedAt { get; set; }
        public DateTime UpdateAt { get; set; }
    }
}