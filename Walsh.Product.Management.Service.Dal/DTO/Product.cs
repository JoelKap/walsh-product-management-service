using System;
using System.Collections.Generic;

namespace Walsh.Product.Management.Service.Dal.DTO
{
    public partial class Product
    {
        public Product()
        {
            ProductReviews = new HashSet<ProductReview>();
        }

        public int ProductId { get; set; }
        public int LocationId { get; set; }
        public int CategoryId { get; set; }
        public int StockId { get; set; }
        public string ProductTitle { get; set; } = null!;
        public string ProductImageUrl { get; set; } = null!;
        public string ProductDescription { get; set; } = null!;
        public bool ProductLike { get; set; }
        public int ProductPrice { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdateAt { get; set; }

        public virtual ProductCategory Category { get; set; } = null!;
        public virtual ProductLocation Location { get; set; } = null!;
        public virtual ProductStock Stock { get; set; } = null!;
        public virtual ICollection<ProductReview> ProductReviews { get; set; }
    }
}
