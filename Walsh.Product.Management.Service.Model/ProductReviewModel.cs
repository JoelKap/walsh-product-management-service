namespace Walsh.Product.Management.Service.Model
{
    public class ProductReviewModel
    {
        public int ReviewId { get; set; }
        public int ProductId { get; set; }
        public int ProductRating { get; set; } 
        public string ProductReview { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdateAt { get; set; }
    }
}
