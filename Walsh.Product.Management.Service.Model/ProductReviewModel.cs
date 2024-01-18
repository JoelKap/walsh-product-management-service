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

        public bool Validate(out List<string> messages)
        {
            messages = new List<string>();

            if (ProductId is 0)
            {
                messages.Add("Product is missing");
            }

            if (ProductRating is 0)
            {
                messages.Add("Rating is missing");
            }

            return (messages.Any() == false);
        }
    }
}
