using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApıWithToken.Domain;
using ApıWithToken.Domain.Responses;
using ApıWithToken.Domain.Services;
using ApıWithToken.Extensions;
using ApıWithToken.Resources;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ApıWithToken.DataControl;

namespace ApıWithToken.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IGenericsService<Product> productService;
        private readonly IMapper mapper;

        public ProductsController(IGenericsService<Product> productService,IMapper mapper)
        {
            this.productService = productService;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetList()
        {
            BaseResponse<IEnumerable<Product>> productListResponse = this.productService.GetWhere(x => x.Id > 0);
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
        public IActionResult GetFindById(int id)
        {
            BaseResponse<Product> productResponse =  this.productService.GetById(id);
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
        public IActionResult AddProduct(ProductResource productResource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }
            else
            {
                if (ProductDataControl.validateProductName(productResource.Name) && ProductDataControl.validateProductCategory(productResource.Category) && ProductDataControl.validateProductPrice(productResource.Price)){
                    Product product = mapper.Map<ProductResource, Product>(productResource);
                    product.Name = ProductDataControl.updateProductName(product.Name);
                    product.Category = ProductDataControl.updateCategoryName(product.Category);
                    var Response = this.productService.Add(product);

                    if (Response.Success)
                    {
                        return Ok(Response.Extra);
                    }
                    else
                    {
                        return BadRequest(Response.ErrorMessage);
                    }
                }
                return BadRequest("ürün eklenemedi");
            }
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateProduct(ProductResource productResource, int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }
            else
            {
                Product product = mapper.Map<ProductResource, Product>(productResource);

                product.Id = id;

                var response = this.productService.Update(product);

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
        public IActionResult RemoveProduct(int id)
        {
            BaseResponse<Product> response = productService.Delete(id);

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