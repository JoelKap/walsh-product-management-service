namespace Walsh.Product.Management.Service.Model
{
    public class ProductStockModel
    {
        public int StockId { get; set; }
        public int ProductId { get; set; }
        public string ProductInStock { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdateAt { get; set; }
    }
}
