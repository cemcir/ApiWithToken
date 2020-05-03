using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApıWithToken.Domain.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using ApıWithToken.Domain.Responses;
using ApıWithToken.Resources;
using ApıWithToken.Extensions;
using ApıWithToken.Domain;
using Microsoft.AspNetCore.Authorization;

namespace ApıWithToken.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    //localhost:3333/api/product/productRemove/2
    public class ProductController : ControllerBase
    {
        //private readonly IProductService productService;
        private readonly IGenericService<Product> productService;
        private readonly IMapper mapper;

        public ProductController(IGenericService<Product> productService,IMapper mapper)
        {
            this.productService = productService;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            BaseResponse<IEnumerable<Product>> productListResponse = await this.productService.GetWhere(x => x.Id > 0);
            if (productListResponse.Success)
            {
                return Ok(productListResponse.Extra);
            }
            else
            {
                return BadRequest(productListResponse.ErrorMessage);
            }
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetFindById(int id)
        {
            BaseResponse<Product> productResponse = await this.productService.GetById(id);
            if (productResponse.Success)
            {
                return Ok(productResponse.Extra);
            }
            else
            {
                return BadRequest(productResponse.ErrorMessage);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(ProductResource productResource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }
            else
            {
                Product product = mapper.Map<ProductResource, Product>(productResource);

                var Response = await this.productService.Add(product);

                if (Response.Success)
                {
                    return Ok(Response.Extra);
                }
                else
                {
                    return BadRequest(Response.ErrorMessage);
                }
            }
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateProduct(ProductResource productResource,int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }
            else
            {
                Product product = mapper.Map<ProductResource, Product>(productResource);

                product.Id = id;

                var response = await this.productService.Update(product);

                if (response.Success)
                {
                    return Ok(response.Extra);
                }
                else
                {
                    return BadRequest(response.ErrorMessage);
                }
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> RemoveProduct(int id)
        {
            BaseResponse<Product> response = await productService.Delete(id);

            if (response.Success)
            {
                return Ok(response.Extra);
            }
            else
            {
                return BadRequest(response.ErrorMessage);
            }
        }
    }
}