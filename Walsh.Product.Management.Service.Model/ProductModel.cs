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

        public bool Validate(out List<string> messages)
        {
            messages = new List<string>();

            if (LocationId is 0)
            {
                messages.Add("Location is missing");
            }

            if (CategoryId is 0)
            {
                messages.Add("Category is missing");
            }

            if (CategoryId is 0)
            {
                messages.Add("Category is missing");
            }

            if (string.IsNullOrWhiteSpace(ProductTitle))
            {
                messages.Add("Product title is empty");
            }

            if (string.IsNullOrWhiteSpace(ProductDescription))
            {
                messages.Add("Product description is empty");
            }

            if (string.IsNullOrWhiteSpace(ProductImageUrl))
            {
                messages.Add("Image Url is empty");
            }

            return (messages.Any() == false);
        }
    }
}