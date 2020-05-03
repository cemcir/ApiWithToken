using ApıWithToken.Domain.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApıWithToken.Domain.Services
{
    public interface IProductService
    {
        Task<BaseResponse<IEnumerable<Product>>> ListAsync();

        Task<BaseResponse<Product>> AddProduct(Product product);

        Task<BaseResponse<Product>> RemoveProduct(int productId);

        Task<BaseResponse<Product>> UpdateProduct(Product product, int productId);

        Task<BaseResponse<Product>> FindByIdAsync(int productId);
    }
}
