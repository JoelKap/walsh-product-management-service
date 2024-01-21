using System;
using System.Collections.Generic;

namespace Walsh.Product.Management.Service.Dal.DTO
{
    public partial class ProductStock
    {
        public ProductStock()
        {
            Products = new HashSet<Product>();
        }

        public int StockId { get; set; }
        public string ProductInStock { get; set; } = null!;
        public bool IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdateAt { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
