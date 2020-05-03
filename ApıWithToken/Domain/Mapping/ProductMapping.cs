using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApıWithToken.Resources;
using AutoMapper;
namespace ApıWithToken.Domain.Mapping
{
    public class ProductMapping:Profile
    {
        public ProductMapping()
        {
            CreateMap<ProductResource, Product>();
            CreateMap<Product, ProductResource>();
        }
    }
}
