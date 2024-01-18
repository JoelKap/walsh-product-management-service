using System;
using System.Collections.Generic;

namespace Walsh.Product.Management.Service.Dal.DTO
{
    public partial class ProductReview
    {
        public int ReviewId { get; set; }
        public int ProductId { get; set; }
        public int ProductRating { get; set; }
        public string? ProductReview1 { get; set; }

        public virtual Product Product { get; set; } = null!;
    }
}
