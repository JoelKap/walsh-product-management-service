namespace Walsh.Product.Management.Service.Model
{
    public class ProductStockModel
    {
        public int StockId { get; set; }
        public string ProductInStock { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdateAt { get; set; }

        public bool Validate(out List<string> messages)
        {
            messages = new List<string>();

            if (string.IsNullOrWhiteSpace(ProductInStock))
            {
                messages.Add("In stock value is empty");
            }

            return (messages.Any() == false);
        }
    }
}
