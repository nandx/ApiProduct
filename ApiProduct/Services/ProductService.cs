using System.Collections.Generic;
using System.Linq;
using ApiProduct.Configs;
using ApiProduct.Dto;
using ApiProduct.Dto.Common;
using ApiProduct.Models;
using MongoDB.Driver;

namespace ApiProduct.Services
{
    public class ProductService : IProductService
    {
        
        private readonly IMongoCollection<Product> _product;
        
        public ProductService(IMarketplaceDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _product = database.GetCollection<Product>(settings.ProductCollectionName);
        }

        public SearchListDto<ProductDto> Search(ProductParamSearchDto param)
        {
            var listProduct = _product.Find(product => true).ToList();
            var list = listProduct.Select(product => new ProductDto {Productcode = product.ProductCode, Productname = product.ProductName}).ToList();
            var pageData = new PageData(param.Page, param.Size, 3, 4);
            return new SearchListDto<ProductDto>(list, pageData);
        }

        public FormDto<ProductDto> Add(ProductDto productDto)
        {
            // validation
            var totalProduct = _product.Find(prd => prd.ProductCode == productDto.Productcode).CountDocuments();
            if (totalProduct > 0)
                return new FormDto<ProductDto>("PRODUCTCODE_IS_EXIST","Product Code is already registered.",productDto);
            
            var product = new Product {ProductCode = productDto.Productcode, ProductName = productDto.Productname};
            _product.InsertOne(product);
            return new FormDto<ProductDto>(productDto);
        }
    }
}