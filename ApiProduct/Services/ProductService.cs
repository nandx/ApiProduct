using System.Collections.Generic;
using ApiProduct.Dto;
using ApiProduct.Dto.Common;

namespace ApiProduct.Services
{
    public class ProductService : IProductService
    {
        public SearchListDto<ProductDto> search()
        {
            var list = new List<ProductDto>();
            var product = new ProductDto {Productcode = "MIE", Productname = "Indomie Goreng"};
            list.Add(product);

            var pageData = new PageData(1, 2, 3, 4);
            return new SearchListDto<ProductDto>(list, pageData);
        }
    }
}