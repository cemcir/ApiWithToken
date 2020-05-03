using ApıWithToken.Domain.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApıWithToken.Domain.Services
{
    public interface IProductsService
    {
        BaseResponse<IEnumerable<Product>> List();

        BaseResponse<Product> AddProduct(Product product);

        BaseResponse<Product> RemoveProduct(int productId);

        BaseResponse<Product> UpdateProduct(Product product, int productId);

        BaseResponse<Product> FindById(int productId);
    }
}
