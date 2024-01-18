using System;
using System.Collections.Generic;

namespace Walsh.Product.Management.Service.Dal.DTO
{
    public partial class ProductLocation
    {
        public ProductLocation()
        {
            Products = new HashSet<Product>();
        }

        public int LocationId { get; set; }
        public string LocationName { get; set; } = null!;

        public virtual ICollection<Product> Products { get; set; }
    }
}
