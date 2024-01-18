namespace Walsh.Product.Management.Service.Model
{
    public class ProductReviewModel
    {
        public int ReviewId { get; set; }
        public int ProductId { get; set; }
        public int ProductRating { get; set; } 
        public string ProductReview { get; set; }
    }
}
