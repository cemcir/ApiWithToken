﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApıWithToken.Domain.Repository
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> ListAsync();
        Task AddProductAsync(Product product);
        Task RemoveProductAsync(int productId);
        void UpdateProduct(Product product);
        Task<Product> FindByIdAsync(int productId);
    }
}
