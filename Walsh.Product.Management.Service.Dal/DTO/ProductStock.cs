using System;
using System.Collections.Generic;

namespace Walsh.Product.Management.Service.Dal.DTO
{
    public partial class ProductStock
    {
        public int StockId { get; set; }
        public int ProductId { get; set; }
        public string ProductInStock { get; set; } = null!;
        public bool IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdateAt { get; set; }

        public virtual Product Product { get; set; } = null!;
    }
}
