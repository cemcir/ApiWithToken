using ApıWithToken.Domain;
using ApıWithToken.Domain.Repository;
using ApıWithToken.Domain.Responses;
using ApıWithToken.Domain.Services;
using ApıWithToken.Domain.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApıWithToken.DataControl;

namespace ApıWithToken.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository productRepository;
        private readonly IUnitOfWork unitOfWork;

        public ProductService(IProductRepository productRepository, IUnitOfWork unitOfWork)
        {
            this.productRepository = productRepository;
            this.unitOfWork = unitOfWork;
        }

        public async Task<BaseResponse<Product>> AddProduct(Product product)
        {
            try
            {
    
                await this.productRepository.AddProductAsync(product);
                await this.unitOfWork.CompleteAsync();

                return new BaseResponse<Product>(product); 
            }
            catch (Exception ex)
            {
                return new BaseResponse<Product>($"Ürün eklenirken bir hata meydana geldi::{ex.Message}");
            }
        }

        public async Task<BaseResponse<Product>> FindByIdAsync(int productId)
        {
            try
            {
                Product product = await this.productRepository.FindByIdAsync(productId);
                if (product == null)
                {
                    return new BaseResponse<Product>("ürün bulunamamıştır");
                }
                return new BaseResponse<Product>(product);
            }
            catch(Exception ex)
            {
                return new BaseResponse<Product>($"Ürün bulunurken bir hata meydana geldi::{ex.Message}");
            }
        }

        public async Task<BaseResponse<IEnumerable<Product>>> ListAsync()
        {
            try
            {
                IEnumerable<Product> products = await productRepository.ListAsync();
                return new BaseResponse<IEnumerable<Product>>(products);
            }
            catch(Exception ex)
            {
                return new BaseResponse<IEnumerable<Product>>($"Ürün listelerken bir hata meydana geldi::{ex.Message}");
            }
        }

        public async Task<BaseResponse<Product>> RemoveProduct(int productId)
        {
            try
            {
                Product product = await this.productRepository.FindByIdAsync(productId);
                if (product == null)
                {
                    return new BaseResponse<Product>("silmeye çalıştığınız ürün bulunamamıştır");
                }
                else
                {
                    await this.productRepository.RemoveProductAsync(productId);

                    await this.unitOfWork.CompleteAsync();

                    return new BaseResponse<Product>(product);
                }
            }
            catch (Exception ex)
            {
                return new BaseResponse<Product>($"ürün silmeye çalışılırken bir hata meydana geldi{ex.Message}");
            }
        }

        public async Task<BaseResponse<Product>> UpdateProduct(Product product, int productId)
        {
            try
            {
                var firstProduct = await this.productRepository.FindByIdAsync(productId);
                if (firstProduct == null)
                {
                    return new BaseResponse<Product>("güncellemeye çalıştığınız ürün bulunamadı");
                }
                firstProduct.Name = product.Name;
                firstProduct.Category = product.Category;
                firstProduct.Price = product.Price;

                this.productRepository.UpdateProduct(firstProduct);

                await this.unitOfWork.CompleteAsync();

                return new BaseResponse<Product>(firstProduct);
            }
            catch(Exception ex)
            {
                return new BaseResponse<Product>($"ürün güncellenirken bir hata meydana geldi::{ex.Message}");
            }
        }
    }
}
