using ApıWithToken.Domain;
using ApıWithToken.Domain.Responses;
using ApıWithToken.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApıWithToken.Services
{
    public class ProductsService : IProductsService
    {
        

        public BaseResponse<Product> AddProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public BaseResponse<Product> FindById(int productId)
        {
            throw new NotImplementedException();
        }

        public BaseResponse<IEnumerable<Product>> List()
        {
            throw new NotImplementedException();
        }

        public BaseResponse<Product> RemoveProduct(int productId)
        {
            throw new NotImplementedException();
        }

        public BaseResponse<Product> UpdateProduct(Product product, int productId)
        {
            throw new NotImplementedException();
        }
    }
}
