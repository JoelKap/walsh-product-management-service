﻿using Walsh.Product.Management.Service.Model;

namespace Walsh.Product.Management.Service.Dal.Contracts
{ 
    public interface IProductLocationDataAccess
    {
        IEnumerable<ProductLocationModel> GetLocations();
    }
}
 